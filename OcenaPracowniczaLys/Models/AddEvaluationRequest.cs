using Microsoft.IdentityModel.Tokens;

namespace OcenaPracowniczaLys.Models;

public class AddEvaluationRequest
{
    public string? MainDepartment { get; set; }
    public int MainDepartmentID { get; set; }
    public string? Department { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? SupervisorId { get; set; }
    public List<AnswerEntry> Answers { get; set; } = new List<AnswerEntry>();

    public bool IsFull()
    {
        // int questionCount = !MainDepartment.IsNullOrEmpty() && MainDepartment.Equals("Biuro") ? 10 : 4;
        // for (int i = 0; i < questionCount; i++)
        // {
        //     if(Answers[i].Answer.IsNullOrEmpty())
        //         return false;
        // }
        return !string.IsNullOrEmpty(MainDepartment) && !string.IsNullOrEmpty(Department) && !string.IsNullOrEmpty(Name) 
               && !string.IsNullOrEmpty(Position) && !string.IsNullOrEmpty(SupervisorId);
    }
}