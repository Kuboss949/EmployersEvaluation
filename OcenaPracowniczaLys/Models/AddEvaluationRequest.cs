using Microsoft.IdentityModel.Tokens;

namespace OcenaPracowniczaLys.Models;

public class AddEvaluationRequest
{
    public string? MainDepartment { get; set; }
    public string? Department { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? SupervisorId { get; set; }
    public List<string> Questions { get; set; } = Enumerable.Repeat(string.Empty, 11).ToList();

    public bool IsFull()
    {
        int questionCount = !MainDepartment.IsNullOrEmpty() && MainDepartment.Equals("Biuro") ? 10 : 4;
        for (int i = 0; i < questionCount; i++)
        {
            if(Questions[i].IsNullOrEmpty())
                return false;
        }
        return !string.IsNullOrEmpty(MainDepartment) && !string.IsNullOrEmpty(Department) && !string.IsNullOrEmpty(Name) 
               && !string.IsNullOrEmpty(Position) && !string.IsNullOrEmpty(SupervisorId);
    }
}