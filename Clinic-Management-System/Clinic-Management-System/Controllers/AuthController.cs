using BLL.Services;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService AuthService;
        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }
        public IActionResult Login()
        {
                  return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var principal = await AuthService.Login(model.Username, model.Password);

            if (principal == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(model);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

