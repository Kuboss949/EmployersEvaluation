using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public class EvaluationRepository : IEvaluationRepository
{
    private readonly AppDbContext _context;

    public EvaluationRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<OperationResult> AddEvaluationAsync(Evaluation data)
    {
        var result = new OperationResult();
        _context.Evaluations.Add(data);
        
        int status = await _context.SaveChangesAsync();
        
        result.Status = status > 0 ? "Success" : "Failed";
        result.Message = status > 0 
            ? "Opinia została przesłana! Dziękujemy!" 
            : "Oops! Coś poszło nie tak. Zapisz swoje odpowiedzi i skontaktuj się z działem IT";
    
        return result;
    }
    

    public async Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId)
    {
        return await _context.Evaluations
            .Include(e => e.EmployeeAnswers).ThenInclude(answer => answer.Question)
            .Include(e => e.Department)
            .Where(e => e.ManagerId == UserId).ToListAsync();
    }

    public async Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId)
    {
        return await _context.Evaluations
            .Include(e => e.EmployeeAnswers).ThenInclude(answer => answer.Question)
            .Include(e => e.Department)
            .Where(e => _context.Users
                .Where(u => u.ManagerId == UserId)
                .Select(u => u.UserId)
                .Contains(e.ManagerId))
            .ToListAsync();
    }
}