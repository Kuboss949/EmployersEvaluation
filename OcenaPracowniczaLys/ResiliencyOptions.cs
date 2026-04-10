namespace OcenaPracowniczaLys;

public sealed class ResiliencyOptions
{
    public int  RetryCount          { get; init; }
    public int  BaseDelayMs         { get; init; }
    public int  CircuitFailCount    { get; init; }
    public int  CircuitDurationSec  { get; init; }
    public int[] SqlTransientNumbers{ get; init; } = Array.Empty<int>();
}