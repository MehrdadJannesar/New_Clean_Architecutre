using CA.MVC.Contracts;
using CA.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CA.MVC.Models;

namespace CA.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly ILocalStorageService _localStorage;

        public AuthenticateService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor)
            : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _localStorage = localStorage;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticateRequest = new()
                {
                    Email = email,
                    Password = password
                };
                var authenticateResponse = await _client.LoginAsync(authenticateRequest);
                if (authenticateResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorage.SetStorageValue("token", authenticateResponse.Token);

                    return true;
                }

                return false;
            }
            catch
            {

                return false;
            }
        }
        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterViewModel registerViewModel)
        {
            RegistrationRequest registrationRequest = new()
            {
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName
            };
            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.UserId.ToString()))
            {
                return true;
            }

            return false;

        }
        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Claims.FirstOrDefault(c => c.Type == "UserName").Value));
            return claims;
        }
    }
}
