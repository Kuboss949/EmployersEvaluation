using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Components.Pages;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(AppLoginRequest loginRequest)
    {
        var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == loginRequest.Login && u.Enabled);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return null;
        return user;  
    }
}