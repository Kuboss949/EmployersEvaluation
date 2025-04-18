using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartmentsAsync();
    Task<List<MainDepartment>> GetAllMainDepartmentsAsync();
    
    Task<OperationResult> AddDepartmentAsync(Department department);
    Task<OperationResult> ChangeDepartmentManagerAsync(int departmentId, int newManagerId);
    Task<OperationResult> ToggleEnableDepartmentAsync(int departmentId);
    Task<OperationResult> ToggleEnableMainDepartmentAsync(int departmentId);
    Task<OperationResult> AddMainDepartmentAsync(MainDepartment department);

}