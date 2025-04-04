using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Services;


public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> GetAllSupervisorsAsync();
    
}