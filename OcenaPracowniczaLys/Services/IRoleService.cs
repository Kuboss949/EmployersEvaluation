using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Services;

public interface IRoleService
{
     Task<List<Role>> GetAllRolesAsync();
}