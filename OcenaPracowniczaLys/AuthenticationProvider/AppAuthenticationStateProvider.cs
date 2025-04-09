using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.AuthenticationProvider;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    private ClaimsPrincipal _user = null!;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Jeśli użytkownik nie jest zalogowany, zwróć anonimowego
        if (_user == null)
        {
            return Task.FromResult(new AuthenticationState(_anonymous));
        }
        return Task.FromResult(new AuthenticationState(_user));
    }

    public void MarkUserAsAuthenticated(User user)
    {
        // Tworzymy tożsamość z Claimami – można dodać więcej informacji, np. role
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim("UserId", user.UserId.ToString()),
            new Claim(ClaimTypes.Role, user.Role == null ? "user" : user.Role.Name),
        }, "Custom authentication");

        _user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void MarkUserAsLoggedOut()
    {
        _user = _anonymous;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}