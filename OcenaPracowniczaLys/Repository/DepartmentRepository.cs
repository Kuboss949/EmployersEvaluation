using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Exceptions;
using OcenaPracowniczaLys.Models;
using Polly;
using Polly.Registry;

namespace OcenaPracowniczaLys.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;
    private readonly IAsyncPolicy _circuit; 

    public DepartmentRepository(IDbContextFactory<AppDbContext> f)
    {
        _factory = f;
    }
    
    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Departments
                .Include(d => d.Manager)
                .ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
    }

    public async Task<List<MainDepartment>> GetAllMainDepartmentsAsync()
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.MainDepartments.ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
    }

    public async Task<OperationResult> AddDepartmentAsync(Department department)
    {
        var result = new OperationResult();
        
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt działu.";
            return result;
        }

        try
        {
            await using var ctx = _factory.CreateDbContext();
            ctx.Departments.Add(department);
            int status = await ctx.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = $"Dodano dział {department.Name}!";
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
            result.Message = $"Wystąpił błąd podczas tworzenia działu: {ex.Message}";
        }

        return result;
    }


    public async Task<OperationResult> ChangeDepartmentManagerAsync(int departmentId, int newManagerId)
    {
        var result = new OperationResult();
        await using var ctx = _factory.CreateDbContext();

        var department = ctx.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.ManagerId = newManagerId;

        try
        {
            int status = await ctx.SaveChangesAsync();
            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono kierownika działu."; 
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

    public async Task<OperationResult> ToggleEnableDepartmentAsync(int departmentId)
    {
        var result = new OperationResult();
        await using var ctx = _factory.CreateDbContext();

        var department = ctx.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.Enabled = !department.Enabled;

        try
        {
            int status = await ctx.SaveChangesAsync();
            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono stan działu."; 
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
    public async Task<OperationResult> ToggleEnableMainDepartmentAsync(int departmentId)
    {
        var result = new OperationResult();
        await using var ctx = _factory.CreateDbContext();

        var department = ctx.MainDepartments.FirstOrDefault(d => d.MainDepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.Enabled = !department.Enabled;

        try
        {
            int status = await ctx.SaveChangesAsync();
            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono stan działu."; 
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

    public async Task<OperationResult> AddMainDepartmentAsync(MainDepartment department)
    {
        var result = new OperationResult();
        
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt działu.";
            return result;
        }
        await using var ctx = _factory.CreateDbContext();

        try
        {
            ctx.MainDepartments.Add(department);
            int status = await ctx.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = $"Dodano dział {department.Name}!";
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
            result.Message = $"Wystąpił błąd podczas tworzenia działu: {ex.Message}";
        }

        return result;
    }
}