using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IEvaluationRepository
{
    Task<OperationResult> AddEvaluationAsync(Evaluation data);
    Task<OperationResult> AddManagerAnswerAsync(ManagerAnswer data);
    Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId);
    Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId);
    Task<Evaluation?> GetEvaluationByIdAsync(int EvaluationId);
    
    
    
}