using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IEvaluationService
{
    Task<OperationResult> AddOfficeEvaluationAsync(AddEvaluationRequest request);
    Task<OperationResult> AddProductionEvaluationAsync(AddEvaluationRequest request);
    
}