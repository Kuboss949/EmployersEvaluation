using OcenaPracowniczaLys.Data;
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
}