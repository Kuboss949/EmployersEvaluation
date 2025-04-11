using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _repository.GetAllRolesAsync();
    }
}