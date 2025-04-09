using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IEvaluationService
{
    Task<OperationResult> AddEvaluationAsync(AddEvaluationRequest request);
    Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId);
    Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId);
}