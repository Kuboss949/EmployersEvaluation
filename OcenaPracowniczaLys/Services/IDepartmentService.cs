using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Services;

public interface IDepartmentService
{
    public Task<List<Department>> GetAllDepartmentsAsync();
}