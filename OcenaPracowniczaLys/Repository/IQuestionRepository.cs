using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public interface IQuestionRepository
{
    Task<List<Question>> GetQuestionsAsync();
}