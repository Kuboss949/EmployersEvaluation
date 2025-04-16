using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IQuestionService
{
    Task<List<Question>> GetQuestionsAsync();
    Task<List<Question>> GetEnabledQuestionsAsync();
    Task<OperationResult> ToggleEnabledQuestionAsync(int questionId);
    Task<OperationResult> AddQuestionAsync(AddQuestionRequest question);
    Task<OperationResult> ChangeQuestionPriorityAsync(int questionId, int priority);

    
}