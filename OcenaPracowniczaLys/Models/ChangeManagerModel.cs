using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class ChangeManagerModel
{
    [Required(ErrorMessage = "Pole jest wymagane")]
    public int ManagerId { get; set; } = -1;
}