using Microsoft.AspNetCore.Mvc;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Domain.Interfaces;

namespace BooksNotBoobs.Controllers.Authentication
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService) 
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _authService.SignInAsync(login.Email,login.Password);
                if (result) 
                {
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError(string.Empty,"User not found");
               
            }
            return View("Index");
        }

        public IActionResult LogOut() 
        {
            _authService.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }
}
