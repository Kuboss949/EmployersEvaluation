using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> GetAllSupervisorsAsync();
}