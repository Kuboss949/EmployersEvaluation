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
        
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt użytkownika.";
            return result;
        }

        try
        {
            _context.Users.Add(user);
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = $"Dodano użytkownika {user.Login}!";
            }
            else
            {
                result.Status = "Failed";
                result.Message = "Operacja nie powiodła się. Brak zmian w bazie danych.";
            }
        }
        catch (Exception ex)
        {
            result.Status = "Failed";
            result.Message = $"Wystąpił błąd: {ex.Message}";
        }

        return result;
    }

    public async Task<OperationResult> ToggleEnableStatusAsync(int userId)
    {
        var result = new OperationResult();
        
        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            user.Enabled = !user.Enabled;
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono status użytkownika.";
            }
            else
            {
                result.Status = "Failed";
                result.Message = "Operacja nie powiodła się. Brak zmian w bazie danych.";
            }
        }
        catch (Exception ex)
        {
            result.Status = "Failed";
            result.Message = $"Wystąpił błąd: {ex.Message}";
        }

        return result;
    }

    public async Task<OperationResult> ChangePasswordAdminAsync(int userId, string newPassword)
    {
        var result = new OperationResult();
        
        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            user.Password = newPassword;
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Zmieniono hasło użytkownika!";
            }
            else
            {
                result.Status = "Failed";
                result.Message = "Operacja nie powiodła się. Brak zmian w bazie danych.";
            }
        }
        catch (Exception ex)
        {
            result.Status = "Failed";
            result.Message = $"Wystąpił błąd: {ex.Message}";
        }

        return result;
    }
}