using Microsoft.AspNetCore.Mvc;

using AppEmail.Models;
using AppEmail.Resources;
using AppEmail.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace AppEmail.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            User created = await _service.AddUser(user);
            if(created.Id != 0)
            {
                return RedirectToAction("Login", "User");
            }
            ViewData["Message"] = "Failed to create user.";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User searched = await _service.GetUser(email, password);
            if(searched == null) 
            {
                ViewData["Message"] = "No matches found.";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, searched.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }

    }
}
