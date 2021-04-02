using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public async Task<IActionResult> Login(LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.UserName == "test" && user.Password == "test")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("LastChanged", DateTime.UtcNow.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                    );

                await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                new AuthenticationProperties
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                                });

                return RedirectToAction("Index", "Error");
            }
            else
            {
                ModelState.AddModelError("", "Login failed. Please check Username and/or password");
                return View(user);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Error");
        }
    }
}
