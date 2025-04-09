using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Services;

public interface IQuestionService
{
    Task<List<Question>> GetQuestionsAsync();

}