using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

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

    public async Task<OperationResult> AddUserAsync(User user)
    {
        var result = new OperationResult(); 
        _context.Users.Add(user);
        int status = await _context.SaveChangesAsync();
        
         result.Status = status > 0 ? "Success" : "Failed";
         result.Message = status > 0 
             ? $"Dodano użytkownika {user.Login}!" 
             : "Oops! Coś poszło nie tak...";
    
         return result;
    }

    public async Task<OperationResult> ToggleEnableStatusAsync(int userId)
    {
        var result = new OperationResult(); 
        _context.Users.FirstOrDefault(u=>u.UserId == userId).Enabled = !_context.Users.FirstOrDefault(u => u.UserId == userId).Enabled;
        int status = await _context.SaveChangesAsync();
        result.Status = status > 0 ? "Success" : "Failed";
        result.Message = status > 0 
            ? $"Zresetowano hasło użytkownika!" 
            : "Oops! Coś poszło nie tak...";
    
        return result;
    }

    public async Task<OperationResult> ChangePasswordAdminAsync(int userId, string newPassword)
    {
        var result = new OperationResult(); 
        _context.Users.FirstOrDefault(u=>u.UserId == userId).Password = newPassword;
        int status = await _context.SaveChangesAsync();
        result.Status = status > 0 ? "Success" : "Failed";
        result.Message = status > 0 
            ? $"Zmieniono hasło użytkownika!" 
            : "Oops! Coś poszło nie tak...";
    
        return result;
    }
}