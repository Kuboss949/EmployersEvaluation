using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace OcenaPracowniczaLys.Models;

public class AddManagerAnswerRequest
{
    public int EvaluationId { get; set; }
    public List<AnswerEntry> Answers { get; set; } = new List<AnswerEntry>();
}