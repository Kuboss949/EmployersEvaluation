using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IEvaluationService
{
    Task<OperationResult> AddEvaluationAsync(AddEvaluationRequest request);
    Task<List<Evaluation>> GetAllEvaluationsAsync();
    Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int userId);
    Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int userId);
    Task<Evaluation?> GetEvaluationByIdAsync(int evaluationId);
    Task<OperationResult> AddManagerAnswerAsync(AddManagerAnswerRequest request);
    Task<ManagerAnswer?> GetManagerAnswerByEvaluationIdAsync(int evaluationId);
    Task<OperationResult> UpdateManagerAnswerAsync(AddManagerAnswerRequest request);
    Task<List<int>> GetEvaluationAnswerAuthorizedUsersAsync(int userId); 

    
}