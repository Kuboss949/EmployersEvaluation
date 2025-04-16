using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartmentsAsync();
    Task<List<MainDepartment>> GetAllMainDepartmentsAsync();
    
    Task<OperationResult> CreateDepartmentAsync(Department department);
    Task<OperationResult> ChangeDepartmentManagerAsync(int departmentId, int newManagerId);
    Task<OperationResult> ToggleEnableDepartmentAsync(int departmentId);
}