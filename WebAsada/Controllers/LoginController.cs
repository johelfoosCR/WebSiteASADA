using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SystemUserRepository _systemUserRepository;

        public LoginController(SystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string SessionInfo_Name { get; private set; }
        public string SessionInfo_Age { get; private set; }

        [HttpPost] 
        public async Task<ActionResult> DoLogin(SystemUserVM systemUserView)
        {
            var result = await _systemUserRepository.ValidateUserAndPassword(systemUserView);

            if (result.IsSuccess)
            {
                  
                var claims = new List<Claim>
                 {
                 new Claim(ClaimTypes.Name, result.Value.FullName), 
                 new Claim(ClaimTypes.NameIdentifier, result.Value.Id)
                 };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddMinutes(15),
                    AllowRefresh = true
                }); 

                return RedirectToAction("Index", "Dashboard",null);
            }
            else {
                ModelState.AddModelError("", result.Error);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", null);
        }
    }
}