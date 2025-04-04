using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;

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
        return await _context.Departments.ToListAsync();
    }
}