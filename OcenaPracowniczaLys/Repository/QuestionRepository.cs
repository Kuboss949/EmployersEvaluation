using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Exceptions;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;


    public QuestionRepository(IDbContextFactory<AppDbContext> factory)
        => _factory = factory;


    public async Task<List<Question>> GetQuestionsAsync()
    {
        try
        {            
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Questions
                .Include(q => q.MainDepartment)
                .OrderBy(q => q.MainDepartmentId)
                .ThenBy(q => q.Priority)
                .ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
    }

    public async Task<List<Question>> GetEnabledQuestionsAsync()
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Questions
                .Where(q => q.Enabled)
                .OrderBy(q => q.MainDepartmentId)
                .ThenBy(q => q.Priority)
                .ToListAsync();
        }
        catch (DbException ex)
        {
            throw new DataUnavailableException(ex);
        }
    }

    public async Task<OperationResult> ToggleEnabledQuestionAsync(int questionId)
    {
        var result = new OperationResult();
        
        await using var ctx = _factory.CreateDbContext();
        var question = ctx.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        if ( question == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            question.Enabled = !question.Enabled;
            int status = await ctx.SaveChangesAsync();

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
            await using var ctx = _factory.CreateDbContext();
            ctx.Questions.Add(question);
            int status = await ctx.SaveChangesAsync();

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
        
        await using var ctx = _factory.CreateDbContext();
        var question = ctx.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        if ( question == null)
        {
            result.Status = "Failed";
            result.Message = "Nie znaleziono użytkownika o podanym identyfikatorze.";
            return result;
        }

        try
        {
            question.Priority = priority;
            int status = await ctx.SaveChangesAsync();

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