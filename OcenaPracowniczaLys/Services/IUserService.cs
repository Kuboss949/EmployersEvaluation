using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;


public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> GetAllSupervisorsAsync();
    Task<OperationResult> AddUserAsync(AddUserRequest user);
    Task<OperationResult> ToggleEnableStatusAsync(int userId);
    Task<OperationResult> ChangePasswordAdminAsync(int userId, string newPassword);
    Task<OperationResult> ChangeUserManagerAsync(int userId, int? newManagerId);
    
}