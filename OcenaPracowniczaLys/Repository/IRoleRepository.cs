using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public interface IRoleRepository
{
    public Task<List<Role>> GetAllRolesAsync();
}