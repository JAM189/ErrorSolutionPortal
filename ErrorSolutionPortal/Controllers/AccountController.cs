using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ErrorSolutionPortal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }


        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            bool isAuthenticated = false;
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (login.Username == "test" && login.Password == "test")
            {
                var identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.Authentication.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Error");
            }
            else
            {
                ModelState.AddModelError("", "Login failed. Please check Username and/or password");

                return View(login);
            }

            throw new NotImplementedException();
        }
    }
}
