using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OcenaPracowniczaLys.Data;
using OcenaPracowniczaLys.Models;
using OcenaPracowniczaLys.Services;

namespace OcenaPracowniczaLys.AuthenticationProvider;

public class AppAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    private ClaimsPrincipal _user = null!;
    private Task<AuthenticationState>? _cachedState;

    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppAuthStateProvider(IAuthService authService, IHttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }


    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                if (httpContext.Request.Cookies.ContainsKey(BlazorConstants.AuthCookieName))
                {
                    var token = httpContext.Request.Cookies[BlazorConstants.AuthCookieName];
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    var claims = new List<Claim>();
                    foreach (var claim in jsonToken!.Claims)
                    {
                        claims.Add(new Claim(claim.Type, claim.Value));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(claimsIdentity);
                    _cachedState = Task.FromResult(new AuthenticationState(user));
                    return _cachedState;
                }

                // HttpContext dostępny, ale brak ciasteczka – użytkownik wylogowany
                _cachedState = null;
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            }

            // HttpContext niedostępny (faza SignalR) – zwróć zapamiętany stan
            return _cachedState ?? Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
        catch (Exception)
        {
            return _cachedState ?? Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
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
        _cachedState = null;
        _user = _anonymous;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    
    public async Task<string> Login(AppLoginRequest loginRequest)
    {
        var user = await _authService.AuthenticateAsync(loginRequest);

        if (user != null)
        {
            var claimsIdentity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("UserId", user.UserId.ToString()),
            ]);
            
            var token = new JwtSecurityToken(
                issuer: "https://test-issuer.com",
                audience: Guid.NewGuid().ToString(),
                claims: claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),
                    SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        throw new Exception("Invalid username or password");
    }
}