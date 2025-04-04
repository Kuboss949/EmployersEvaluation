namespace OcenaPracowniczaLys.Models;

public class AddEvaluationRequest
{
    public string? Department { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? SupervisorId { get; set; }
    public string? Answer1 { get; set; }
    public string? Answer2 { get; set; }
    public string? Answer3 { get; set; }
}