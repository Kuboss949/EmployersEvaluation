using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IDepartmentService
{
    public Task<List<Department>> GetAllDepartmentsAsync();
    public Task<List<MainDepartment>> GetAllMainDepartmentsAsync();
    
    Task<OperationResult> CreateDepartmentAsync(CreateDepartmentRequest department);
    Task<OperationResult> ChangeDepartmentManagerAsync(int departmentId, int newManagerId);
    
    Task<OperationResult> ToggleEnableDepartmentAsync(int departmentId);
    Task<OperationResult> ToggleEnableMainDepartmentAsync(int departmentId);
    Task<OperationResult> AddMainDepartmentAsync(AddMainDepartmentRequest request);
}