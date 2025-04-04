using Microsoft.AspNetCore.Identity.Data;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;

namespace OcenaPracowniczaLys.Services;

public interface IAuthService
{
    Task<User?> AuthenticateAsync(AppLoginRequest loginRequest);
}