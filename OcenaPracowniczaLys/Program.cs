using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using OcenaPracowniczaLys;
using OcenaPracowniczaLys.AuthenticationProvider;
using OcenaPracowniczaLys.Components;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Repository;
using OcenaPracowniczaLys.Services;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddBlazoredToast();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<AuthenticationStateProvider, AppAuthStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapGet("/postlogin", (string? token, HttpResponse res) =>
{
    if (string.IsNullOrEmpty(token))
        return Results.Redirect("/login");

    res.Cookies.Append(BlazorConstants.AuthCookieName, token, new CookieOptions {
        HttpOnly = true,
        Expires  = DateTimeOffset.UtcNow.AddHours(1)
    });
    return Results.Redirect("/");
});

app.MapGet("/logout", (HttpResponse response) =>
{
    response.Cookies.Delete(BlazorConstants.AuthCookieName);
    return Results.Redirect("/login");
});


app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();