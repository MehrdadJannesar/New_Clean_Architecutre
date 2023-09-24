using CA.Application.AuthModels;
using CA.Application.Constant;
using CA.Application.Contracts.Identity;
using CA.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Identity.Services
{
    public class AuthService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSettings> _jwtSetting;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSetting, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSetting = jwtSetting;
            _signInManager = signInManager;
        }

        #region Register
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existUser = await _userManager.FindByNameAsync(request.UserName);
            if (existUser != null)
            {
                throw new Exception($"User name {request.UserName} already exists!");
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail != null)
            {
                throw new Exception($"Email {request.Email} already exists!");
            }
            else
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return new RegistrationResponse() { UserId = new Guid(user.Id) };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }

        }
        #endregion

        #region Login
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"'{request.Email}' not found !");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception($"you can't login, please check email or password !");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse()
            {
                Id = new Guid(user.Id),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            return response;
        } 
        #endregion

        #region GenerateTokenUtilities
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(CustomClaimTypes.UserName, user.UserName),
                new Claim(CustomClaimTypes.Uid, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }.Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Value.Issuer,
                audience: _jwtSetting.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.Value.DurationTokenInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;

        }
        #endregion
    }
}
