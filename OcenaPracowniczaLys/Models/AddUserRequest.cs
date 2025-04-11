namespace OcenaPracowniczaLys.Models;

public class AddUserRequest
{
    public string FullName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
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