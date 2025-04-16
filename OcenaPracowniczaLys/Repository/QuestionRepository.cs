using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public class QuestionRepository : IQuestionRepository
{
    private AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetQuestionsAsync()
    {
        return await _context.Questions
            .Include(q => q.MainDepartment)
            .OrderBy(q=>q.MainDepartmentId)
            .ThenBy(q => q.Priority)
            .ToListAsync();
    }

    public async Task<List<Question>> GetEnabledQuestionsAsync()
    {
        return await _context.Questions
            .Where(q=>q.Enabled == true)
            .OrderBy(q=>q.MainDepartmentId)
            .ThenBy(q => q.Priority)
            .ToListAsync();
    }

    public async Task<OperationResult> ToggleEnabledQuestionAsync(int questionId)
    {
        var result = new OperationResult();
        
        var question = _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        if ( question == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            question.Enabled = !question.Enabled;
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono status pytania.";
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

    public async Task<OperationResult> AddQuestionAsync(Question question)
    {
        var result = new OperationResult();
        
        if (question == null)
        {
            result.Status = "Failed";
            result.Message = "Przekazano nieprawidłowy obiekt użytkownika.";
            return result;
        }

        try
        {
            _context.Questions.Add(question);
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = $"Dodano pytanie!";
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

    public async Task<OperationResult> ChangeQuestionPriorityAsync(int questionId, int priority)
    {
        var result = new OperationResult();
        
        var question = _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        if ( question == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            question.Priority = priority;
            int status = await _context.SaveChangesAsync();

            if (status > 0)
            {
                result.Status = "Success";
                result.Message = "Pomyślnie zmieniono priorytet pytania.";
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