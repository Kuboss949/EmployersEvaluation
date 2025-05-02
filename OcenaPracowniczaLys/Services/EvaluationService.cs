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

    public async Task<List<Evaluation>> GetAllEvaluationsAsync()
    {
        return await _repository.GetAllEvaluationsAsync();
    }

    public async Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId)
    {
        return await _repository.GetAllDirectEvaluationsAsync(UserId);
    }

    public async Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId)
    {
        return await _repository.GetAllIndirectEvaluationsAsync(UserId);
    }

    public async Task<Evaluation?> GetEvaluationByIdAsync(int EvaluationId)
    {
        return await _repository.GetEvaluationByIdAsync(EvaluationId);
    }

    public async Task<OperationResult> AddManagerAnswerAsync(AddManagerAnswerRequest request)
    {
        var managerAnswer = new ManagerAnswer()
        {
            EvaluationId = request.EvaluationId,
        };
        
        List<ManagerAnswersText> answers = new List<ManagerAnswersText>();
        
        foreach (var entry in request.Answers)
        {
            var answer = new ManagerAnswersText()
            {
                AnswerText = entry.Answer,
                QuestionId = entry.QuestionId
            };
            answers.Add(answer);
        }
        managerAnswer.ManagerAnswersTexts = answers;
        return await _repository.AddManagerAnswerAsync(managerAnswer);
    }

    public async Task<ManagerAnswer?> GetManagerAnswerByEvaluationIdAsync(int evaluationId)
    {
        return await _repository.GetManagerAnswerByEvaluationIdAsync(evaluationId);
    }

    public async Task<OperationResult> UpdateManagerAnswerAsync(AddManagerAnswerRequest request)
    {
        var result = new OperationResult();

        // 1) Załaduj agregat z tekstami
        var entity = await _repository.GetManagerAnswerByEvaluationIdAsync(request.EvaluationId);
        if (entity == null)
        {
            return new OperationResult {
                Status  = "Failed",
                Message = "Nie znaleziono istniejącej oceny"
            };
        }

        // 2) Zbuduj słownik istniejących tekstów po QuestionId
        var existingByQ = entity.ManagerAnswersTexts
            .ToDictionary(x => x.QuestionId);

        // 3) Usuń te, których już nie ma w request.Answers
        var toRemove = entity.ManagerAnswersTexts
            .Where(x => !request.Answers.Any(a => a.QuestionId == x.QuestionId))
            .ToList();
        if (toRemove.Count > 0)
            _repository.RemoveManagerAnswerTexts(toRemove);

        // 4) Dla każdego entry z request albo aktualizuj, albo dodawaj
        foreach (var ans in request.Answers)
        {
            if (existingByQ.TryGetValue(ans.QuestionId, out var text))
            {
                text.AnswerText = ans.Answer;            // update
            }
            else
            {
                entity.ManagerAnswersTexts.Add(         // nowy
                    new ManagerAnswersText {
                        QuestionId = ans.QuestionId,
                        AnswerText = ans.Answer
                    });
            }
        }

        // 5) Zapisz zmiany
        return await _repository.UpdateManagerAnswerAsync(entity);
    }

    public async Task<List<int>> GetEvaluationAnswerAuthorizedUsersAsync(int userId)
    {
        return await _repository.GetEvaluationAnswerAuthorizedUsersAsync(userId);
    }
}