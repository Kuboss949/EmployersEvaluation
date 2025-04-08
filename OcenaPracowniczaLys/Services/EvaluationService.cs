using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;
/*
 * This class has 2 separate methods, because of previous database structure: TODO fix database structure
 */
public class EvaluationService : IEvaluationService
{
    private readonly IEvaluationRepository _repository;

    public EvaluationService(IEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> AddOfficeEvaluationAsync(AddEvaluationRequest request)
    {
        Evaluationbiuro data = new Evaluationbiuro();
        data.UserName = request.Name;
        data.Date = DateTime.Now;
        data.Stanowisko = request.Position;
        if (request.Department != null) data.DepartmentId = int.Parse(request.Department);
        if (request.SupervisorId != null) data.UserId = int.Parse(request.SupervisorId);
        data.EvaluationAnswerId = 0;
        data.EvaluatorNameId = 2;
        for (int i = 0; i < 11; i++)
        {
            var propertyName = $"Question{i + 1}";
            var propertyInfo = data.GetType().GetProperty(propertyName);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(data, request.Questions[i]);
            }
        }
        return await _repository.AddOfficeEvaluationAsync(data);
        
    }
    

    public async Task<OperationResult> AddProductionEvaluationAsync(AddEvaluationRequest request)
    {
        Evaluationsprodukcja data = new Evaluationsprodukcja();
        data.UserName = request.Name;
        data.Date = DateTime.Now;
        data.Stanowisko = request.Position;
        if (request.Department != null) data.DepartmentId = int.Parse(request.Department);
        if (request.SupervisorId != null) data.UserId = int.Parse(request.SupervisorId);
        data.EvaluationAnswerId = 0;
        data.EvaluatorNameId = 2;
        for (int i = 0; i < 5; i++)
        {
            var propertyName = $"Question{i + 1}";
            var propertyInfo = data.GetType().GetProperty(propertyName);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(data, request.Questions[i]);
            }
        }
        return await _repository.AddProductionEvaluationAsync(data);
    }

    public async Task<List<Evaluationbiuro>> GetAllDirectEvaluationsOfficeAsync(int UserId)
    {
        return await _repository.GetAllDirectEvaluationsOfficeAsync(UserId);
    }

    public async Task<List<Evaluationbiuro>> GetAllIndirectEvaluationsOfficeAsync(int UserId)
    {
        return await _repository.GetAllIndirectEvaluationsOfficeAsync(UserId);
    }

    public async Task<List<Evaluationsprodukcja>> GetAllDirectEvaluationsProductionAsync(int UserId)
    {
        return await _repository.GetAllDirectEvaluationsProductionAsync(UserId);
    }

    public async Task<List<Evaluationsprodukcja>> GetAllIndirectEvaluationsProductionAsync(int UserId)
    {
        return await _repository.GetAllIndirectEvaluationsProductionAsync(UserId);
    }
}