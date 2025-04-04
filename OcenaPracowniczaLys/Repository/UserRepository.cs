using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public class UserRepository : IUserRepository
{
    private AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<List<User>> GetAllSupervisorsAsync()
    {
        return await _context.Users.Where(u => u.RoleId != 2 && u.Enabled).ToListAsync();
    }
}