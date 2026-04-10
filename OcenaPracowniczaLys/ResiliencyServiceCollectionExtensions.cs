namespace OcenaPracowniczaLys;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Registry;

public static class ResiliencyServiceCollectionExtensions
{
    private const string RegistryName = "PollyRegistry";   // łatwo odnaleźć

    public static IServiceCollection AddResiliencyPolicies(this IServiceCollection services,
                                                           IConfiguration config)
    {
        services.Configure<ResiliencyOptions>(config.GetSection("Resiliency"));

        // Rejestrujemy PolicyRegistry w DI
        services.AddSingleton<IReadOnlyPolicyRegistry<string>>(sp =>
        {
            var opt = sp.GetRequiredService<IOptions<ResiliencyOptions>>().Value;
            var registry = new PolicyRegistry();

            registry.Add("SqlRetry", BuildRetry(opt));
            registry.Add("SqlCircuit", BuildCircuit(opt));
            registry.Add("SqlResilient", Policy.WrapAsync(
                                registry.Get<IAsyncPolicy>("SqlRetry"),
                                registry.Get<IAsyncPolicy>("SqlCircuit")));

            return registry;
        });

        return services;
    }

    // ---------- prywatne „fabryki” polityk ----------
    private static IAsyncPolicy BuildRetry(ResiliencyOptions o) =>
        Policy.Handle<SqlException>(ex => IsTransient(ex, o))
              .WaitAndRetryAsync(
                  Backoff.ExponentialBackoff(TimeSpan.FromMilliseconds(o.BaseDelayMs),
                                              o.RetryCount),
                  onRetry: (ex, ts, attempt, ctx) =>
                      LogWarning($"Retry {attempt}/{o.RetryCount} in {ts}. {ex.Message}"));

    private static IAsyncPolicy BuildCircuit(ResiliencyOptions o) =>
        Policy.Handle<SqlException>()
            .CircuitBreakerAsync(
                exceptionsAllowedBeforeBreaking: o.CircuitFailCount,          // ← właściwa nazwa
                durationOfBreak:            TimeSpan.FromSeconds(o.CircuitDurationSec),

                // delegate'y można zostawić - ważne, by pierwszym parametrem było Exception
                onBreak:   (Exception ex, TimeSpan ts) => LogWarning($"Circuit OPEN {ts}. {ex.Message}"),
                onReset:   () => LogInfo("Circuit CLOSED"),
                onHalfOpen:() => LogInfo("Circuit HALF-OPEN"));

    private static bool IsTransient(SqlException ex, ResiliencyOptions o)
        => o.SqlTransientNumbers.Contains(ex.Number);

    private static void LogWarning(string msg) => Console.ForegroundColor = ConsoleColor.Yellow;  // zamień na ILogger
    private static void LogInfo(string msg)    => Console.ResetColor();
}