using System.ComponentModel.DataAnnotations;

namespace OcenaPracowniczaLys.Models;

public class AddUserRequest
{
    [Required(ErrorMessage = "Pole nazwa jest wymagane")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Pole login jest wymagane")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Pole hasło jest wymagane")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Wybranie roli jest wymagane")]
    public int RoleId { get; set; }
    public int? ManagerId { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FullName) 
               && !string.IsNullOrEmpty(Login) 
               && !string.IsNullOrEmpty(Password) 
               && RoleId > 0;
    }
}