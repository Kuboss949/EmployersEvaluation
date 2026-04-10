using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Exceptions;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;


    public UserRepository(IDbContextFactory<AppDbContext> factory)
        => _factory = factory;
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Users.ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
    }

    public async Task<List<User>> GetAllSupervisorsAsync()
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Users
                .Where(u => u.RoleId != 2 && u.Enabled)
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
        
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
            await using var ctx = _factory.CreateDbContext();
            ctx.Users.Add(user);
            int status = await ctx.SaveChangesAsync();

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
        
        await using var ctx = _factory.CreateDbContext();
        var user = ctx.Users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            user.Enabled = !user.Enabled;
            int status = await ctx.SaveChangesAsync();

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
        
        await using var ctx = _factory.CreateDbContext();
        var user = ctx.Users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            user.Password = newPassword;
            int status = await ctx.SaveChangesAsync();

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

    public async Task<OperationResult> ChangeUserManagerAsync(int userId, int? newManagerId)
    {
        var result = new OperationResult();
        
        await using var ctx = _factory.CreateDbContext();
        var user = ctx.Users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            user.ManagerId = newManagerId;
            int status = await ctx.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Zmieniono kierownika!";
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