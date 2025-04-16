using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Question>> GetQuestionsAsync()
    {
        return await _repository.GetQuestionsAsync();
    }

    public async Task<List<Question>> GetEnabledQuestionsAsync()
    {
        return await _repository.GetEnabledQuestionsAsync();
    }

    public async Task<OperationResult> ToggleEnabledQuestionAsync(int questionId)
    {
        return await _repository.ToggleEnabledQuestionAsync(questionId);
    }

    public async Task<OperationResult> AddQuestionAsync(AddQuestionRequest request)
    {
        Question newQuestion = new Question
        {
            QuestionText = request.QuestionText,
            MainDepartmentId = request.MainDepartmentId,
            Priority = request.Priority,
            Enabled = true
        };
        return await _repository.AddQuestionAsync(newQuestion);
    }

    public async Task<OperationResult> ChangeQuestionPriorityAsync(int questionId, int priority)
    {
        return await _repository.ChangeQuestionPriorityAsync(questionId, priority);
    }
}