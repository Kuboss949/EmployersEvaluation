using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IQuestionRepository
{
    Task<List<Question>> GetQuestionsAsync();
    Task<List<Question>> GetEnabledQuestionsAsync();
    Task<OperationResult> ToggleEnabledQuestionAsync(int questionId);
    Task<OperationResult> AddQuestionAsync(Question question);
    Task<OperationResult> ChangeQuestionPriorityAsync(int questionId, int priority);
}