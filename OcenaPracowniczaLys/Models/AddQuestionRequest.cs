using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class AddQuestionRequest
{
    [Required(ErrorMessage = "Pole treść jest wymagane")]
    public string QuestionText { get; set; }
    [Required(ErrorMessage = "Pole priorytet jest wymagane")]
    [Range(1, int.MaxValue, ErrorMessage = "Pole priorytet musi być większe od 0")]
    public int Priority { get; set; }
    [Required(ErrorMessage = "Pole dział jest wymagane")]
    public int MainDepartmentId { get; set; }
}