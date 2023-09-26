using CA.Application.AuthModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Contracts.Identity
{
    public interface IAuthenticationServices
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
