using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartmentsAsync();
}