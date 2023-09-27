using CA.MVC.Models;

namespace CA.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterViewModel registerViewModel);
        Task Logout();
    }
}
