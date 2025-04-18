using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departments.Include(d=>d.Manager).ToListAsync();
    }
    
    public async Task<List<MainDepartment>> GetAllMainDepartmentsAsync()
    {
        return await _context.MainDepartments.ToListAsync();
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
            _context.Departments.Add(department);
            int status = await _context.SaveChangesAsync();

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
        
        var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.ManagerId = newManagerId;

        try
        {
            int status = await _context.SaveChangesAsync();
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
        
        var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.Enabled = !department.Enabled;

        try
        {
            int status = await _context.SaveChangesAsync();
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
        
        var department = _context.MainDepartments.FirstOrDefault(d => d.MainDepartmentId == departmentId);
        if (department == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono działu o podanym identyfikatorze."; 
            return result;
        }
        
        department.Enabled = !department.Enabled;

        try
        {
            int status = await _context.SaveChangesAsync();
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

        try
        {
            _context.MainDepartments.Add(department);
            int status = await _context.SaveChangesAsync();

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