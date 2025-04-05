namespace OcenaPracowniczaLys.Models;

public class AddEvaluationRequest
{
    public string? MainDepartment { get; set; }
    public string? Department { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? SupervisorId { get; set; }
    public List<string> Questions { get; set; } = Enumerable.Repeat(string.Empty, 11).ToList();
}