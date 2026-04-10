using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;


    public RoleRepository(IDbContextFactory<AppDbContext> factory)
        => _factory = factory;

    public async Task<List<Role>> GetAllRolesAsync()
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.Roles.ToListAsync();
    }
}