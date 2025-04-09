using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Context;
using OcenaPracowniczaLys.Data;

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
        return await _context.Questions.ToListAsync();
    }
}