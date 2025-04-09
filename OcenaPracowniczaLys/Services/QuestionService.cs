using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Question>> GetQuestionsAsync()
    {
        return await _repository.GetQuestionsAsync();
    }
}