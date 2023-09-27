using CA.MVC.Contracts;
using CA.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        #region Login
        public IActionResult Login(string ReturnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            ReturnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticateService.Authenticate(loginViewModel.Email, loginViewModel.Password);
            if (isLoggedIn)
            {
                return LocalRedirect(ReturnUrl);
            }
            ModelState.AddModelError("", "Login failed!");
            return View(loginViewModel);
        }
        #endregion

        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authenticateService.Logout();
            return LocalRedirect("/Users/Login");
        }
        #endregion

        #region Register
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var isCreated = await _authenticateService.Register(registerViewModel);

            if (isCreated)
            {
                return LocalRedirect("/Users/Login");
            }
            ModelState.AddModelError("", "Registeration Failed!");
            return View();
        } 
        #endregion
    }
}
