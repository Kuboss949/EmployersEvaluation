using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Repository;

namespace OcenaPracowniczaLys.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<List<User>> GetAllSupervisorsAsync()
    {
        return await _userRepository.GetAllSupervisorsAsync();
    }

    public async Task<OperationResult> AddUserAsync(AddUserRequest user)
    {
        User newUser = new User
        {
            FullName = user.FullName,
            Login = user.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
            ManagerId = user.ManagerId,
            RoleId = user.RoleId,
            Enabled = true
        };
        
        return await _userRepository.AddUserAsync(newUser);
    }

    public async Task<OperationResult> ToggleEnableStatusAsync(int userId)
    {
        return await _userRepository.ToggleEnableStatusAsync(userId);
    }

    public async Task<OperationResult> ChangePasswordAdminAsync(int userId, string newPassword)
    {
        newPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
        return await _userRepository.ChangePasswordAdminAsync(userId, newPassword);
    }

    public async Task<OperationResult> ChangeUserManagerAsync(int userId, int? newManagerId)
    {
        return await _userRepository.ChangeUserManagerAsync(userId, newManagerId);
    }
}