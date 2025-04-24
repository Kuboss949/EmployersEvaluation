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
        
        if (data == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt użytkownika.";
            return result;
        }

        try
        {
            _context.Evaluations.Add(data);
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie dodano odpowiedź. Dziękujemy!";
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

    public async Task<OperationResult> AddManagerAnswerAsync(ManagerAnswer data)
    {
        var result = new OperationResult();
        
        if (data == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt użytkownika.";
            return result;
        }

        try
        {
            _context.ManagerAnswers.Add(data);
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = $"Dodano odpowiedź do ankiety!";
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


    public async Task<List<Evaluation>> GetAllDirectEvaluationsAsync(int UserId)
    {
        return await _context.Evaluations
            .Include(e => e.EmployeeAnswers)
                .ThenInclude(answer => answer.Question)
            .Include(e => e.Department)
            .Include(e=>e.ManagerAnswer)
                .ThenInclude(ma=>ma!.ManagerAnswersTexts)
            .Where(e => e.ManagerId == UserId)
            .ToListAsync();
    }

    public async Task<List<Evaluation>> GetAllIndirectEvaluationsAsync(int UserId)
    {
        var idList = await GetSubordinateIdsAsync(UserId);
        return await _context.Evaluations
            .Include(e => e.EmployeeAnswers).ThenInclude(answer => answer.Question)
            .Include(e => e.Department)
            .Include(e=>e.ManagerAnswer)
            .ThenInclude(ma=>ma!.ManagerAnswersTexts)
            .Where(e => idList.Contains(e.ManagerId))
            .ToListAsync();
    }

    public async Task<Evaluation?> GetEvaluationByIdAsync(int EvaluationId)
    {
        return await _context.Evaluations
            .Include(e => e.EmployeeAnswers)
            .ThenInclude(answer => answer.Question)
            .Include(e => e.Department).FirstOrDefaultAsync(e => e.EvaluationId == EvaluationId);
    }


    private async Task<List<int>> GetSubordinateIdsAsync(int managerId)
    {
        var result = new List<int>();
        var queue = new Queue<int>();
        queue.Enqueue(managerId);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Pobrane tylko Id potomków danego managera
            var directReports = await _context.Users
                .Where(u => u.ManagerId == current)
                .Select(u => u.UserId)
                .ToListAsync();

            foreach (var subId in directReports)
            {
                result.Add(subId);
                queue.Enqueue(subId);
            }
        }

        return result;
    }
}