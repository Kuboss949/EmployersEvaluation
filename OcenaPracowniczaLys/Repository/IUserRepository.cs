using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> GetAllSupervisorsAsync();
    Task<OperationResult> AddUserAsync(User user);
    Task<OperationResult> ToggleEnableStatusAsync(int userId);
    Task<OperationResult> ChangePasswordAdminAsync(int userId, string newPassword);
    Task<OperationResult> ChangeUserManagerAsync(int userId, int? newManagerId);
    
}