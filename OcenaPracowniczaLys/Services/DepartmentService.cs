using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await _repository.GetAllDepartmentsAsync();
    }

    public async Task<List<MainDepartment>> GetAllMainDepartmentsAsync()
    {
        return await _repository.GetAllMainDepartmentsAsync();
    }
    

    public async Task<OperationResult> CreateDepartmentAsync(CreateDepartmentRequest request)
    {
        Department department = new Department()
        {
            Name = request.Name,
            ManagerId = request.ManagerId,
            Enabled = true
        };
        return await _repository.CreateDepartmentAsync(department);
    }

    public async Task<OperationResult> ChangeDepartmentManagerAsync(int departmentId, int newManagerId)
    {
        return await _repository.ChangeDepartmentManagerAsync(departmentId, newManagerId);
    }

    public async Task<OperationResult> ToggleEnableDepartmentAsync(int departmentId)
    {
        return await _repository.ToggleEnableDepartmentAsync(departmentId);
    }
}