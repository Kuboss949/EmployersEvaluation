using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IEvaluationService
{
    Task<OperationResult> AddOfficeEvaluationAsync(AddEvaluationRequest request);
    Task<OperationResult> AddProductionEvaluationAsync(AddEvaluationRequest request);
    Task<List<Evaluationbiuro>> GetAllDirectEvaluationsOfficeAsync(int UserId);
    Task<List<Evaluationbiuro>> GetAllIndirectEvaluationsOfficeAsync(int UserId);
    Task<List<Evaluationsprodukcja>> GetAllDirectEvaluationsProductionAsync(int UserId);
    Task<List<Evaluationsprodukcja>> GetAllIndirectEvaluationsProductionAsync(int UserId);
}