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

    public async Task<OperationResult> AddOfficeEvaluationAsync(Evaluationbiuro data)
    {
        var result = new OperationResult();
        _context.Evaluationbiuros.Add(data);
        int status = await _context.SaveChangesAsync();
        result.Status = status > 0 ? "Success" : "Failed";
        result.Message = status > 0 ? "Opinia została przesłana! Dziękujemy!" : 
            "Oops! Coś poszło nie tak. Zapisz swoje odpowiedzi i skontaktuj się z działem IT";
        return result;
    }

    public async Task<OperationResult> AddProductionEvaluationAsync(Evaluationsprodukcja data)
    {
        var result = new OperationResult();
        _context.Evaluationsprodukcjas.Add(data);
        int status = await _context.SaveChangesAsync();
        result.Status = status > 0 ? "Success" : "Failed";
        result.Message = status > 0 ? "Opinia została przesłana! Dziękujemy!" : 
            "Oops! Coś poszło nie tak. Zapisz swoje odpowiedzi i skontaktuj się z działem IT";
        return result;
    }

    public async Task<List<Evaluationbiuro>> GetAllDirectEvaluationsOfficeAsync(int UserId)
    {
        return await _context.Evaluationbiuros.Where(e => e.UserId == UserId).ToListAsync();
    }

    public async Task<List<Evaluationbiuro>> GetAllIndirectEvaluationsOfficeAsync(int UserId)
    {
        // var subordinates = await _context.Users.Where(u=>u.ManagerId == UserId)
        //     .ToListAsync();
        // var subordinateIDs = subordinates.Select(u=>u.UserId).ToList();
        // return await _context.Evaluationbiuros.Where(e => subordinateIDs.Contains(e.UserId)).ToListAsync();
        return await _context.Evaluationbiuros
            .Where(e => _context.Users
                .Where(u => u.ManagerId == UserId)
                .Select(u => u.UserId)
                .Contains(e.UserId))
            .ToListAsync();
    }

    public async Task<List<Evaluationsprodukcja>> GetAllDirectEvaluationsProductionAsync(int UserId)
    {
        return await _context.Evaluationsprodukcjas.Where(e => e.UserId == UserId).ToListAsync();
    }

    public async Task<List<Evaluationsprodukcja>> GetAllIndirectEvaluationsProductionAsync(int UserId)
    {
        return await _context.Evaluationsprodukcjas
            .Where(e => _context.Users
                .Where(u => u.ManagerId == UserId)
                .Select(u => u.UserId)
                .Contains(e.UserId))
            .ToListAsync();
    }
}