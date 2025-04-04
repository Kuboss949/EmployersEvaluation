using OcenaPracowniczaLys.Data;
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
}