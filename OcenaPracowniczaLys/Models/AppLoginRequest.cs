using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class AppLoginRequest
{
    [Required(ErrorMessage = "Login jest wymagany")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "Hasło jest wymagane")]
    public string Password { get; set; } = string.Empty;
}