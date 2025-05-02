using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IEvaluationRepository
{
    Task<OperationResult> AddEvaluationAsync(Evaluation data);
    Task<OperationResult> AddManagerAnswerAsync(ManagerAnswer data);
    Task<List<Evaluation>> GetAllEvaluationsAsync();
    Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int userId);
    Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int userId);
    Task<Evaluation?> GetEvaluationByIdAsync(int evaluationId);
    Task<ManagerAnswer?> GetManagerAnswerByEvaluationIdAsync(int evaluationId);
    Task<OperationResult> UpdateManagerAnswerAsync(ManagerAnswer data);
    void RemoveManagerAnswerTexts(IEnumerable<ManagerAnswersText> texts);
    Task<List<int>> GetEvaluationAnswerAuthorizedUsersAsync(int userId); 
}