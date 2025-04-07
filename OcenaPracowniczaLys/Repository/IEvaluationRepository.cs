using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IEvaluationRepository
{
    Task<OperationResult> AddOfficeEvaluationAsync(Evaluationbiuro data);
    Task<OperationResult> AddProductionEvaluationAsync(Evaluationsprodukcja data);
}