namespace OcenaPracowniczaLys.Models;

public class AnswerEntry
{
    public int QuestionId { get; set; }
    public string QuestionContent { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}