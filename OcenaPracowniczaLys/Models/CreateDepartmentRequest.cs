using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class CreateDepartmentRequest
{
    [Required(ErrorMessage = "Pole nazwa jest wymagane")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Pole kierownik jest wymagane")]
    public int ManagerId { get; set; }
}