using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class EvaluationService : IEvaluationService
{
    private readonly IEvaluationRepository _repository;

    public EvaluationService(IEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> AddEvaluationAsync(AddEvaluationRequest request)
    {
        Evaluation data = new Evaluation
        {
            EmployeeName = request.Name,
            CreatedAt = DateTime.Now,
            EmployeePosition = request.Position,
            MainDepartmentId = request.MainDepartmentID
        };
        
        if (!string.IsNullOrEmpty(request.Department))
            data.DepartmentId = int.Parse(request.Department);
        if (!string.IsNullOrEmpty(request.SupervisorId))
            data.ManagerId = int.Parse(request.SupervisorId);
        
        List<EmployeeAnswer> answers = new List<EmployeeAnswer>();
        
        foreach (var entry in request.Answers)
        {
            EmployeeAnswer answer = new EmployeeAnswer
            {
                AnswerText = entry.Answer,
                QuestionId = entry.QuestionId
            };
            answers.Add(answer);
        }
        data.EmployeeAnswers = answers;
        
        return await _repository.AddEvaluationAsync(data);
    }

    public async Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId)
    {
        return await _repository.GetAllDirectEvaluationsAsync(UserId);
    }

    public async Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId)
    {
        return await _repository.GetAllIndirectEvaluationsAsync(UserId);
    }

    
}