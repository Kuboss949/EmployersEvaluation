using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class AddMainDepartmentRequest
{
    [Required(ErrorMessage = "Pole nazwa jest wymagane")]
    public string Name { get; set; }
}