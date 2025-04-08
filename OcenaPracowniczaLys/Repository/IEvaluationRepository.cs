using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IEvaluationRepository
{
    Task<OperationResult> AddOfficeEvaluationAsync(Evaluationbiuro data);
    Task<OperationResult> AddProductionEvaluationAsync(Evaluationsprodukcja data);
    Task<List<Evaluationbiuro>> GetAllDirectEvaluationsOfficeAsync(int UserId);
    Task<List<Evaluationbiuro>> GetAllIndirectEvaluationsOfficeAsync(int UserId);
    Task<List<Evaluationsprodukcja>> GetAllDirectEvaluationsProductionAsync(int UserId);
    Task<List<Evaluationsprodukcja>> GetAllIndirectEvaluationsProductionAsync(int UserId);
    
}