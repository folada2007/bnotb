using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BooksNotBoobs.Domain.Services
{
    public class AuthService:IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthService(SignInManager<User> manager, UserManager<User> userManager)
        {
            _signInManager = manager;
            _userManager = userManager;
        }

        public async Task<bool> SignInAsync(string mail, string password) 
        {
            var user = await _userManager.FindByEmailAsync(mail);
            if (user == null) { return false; }
            
            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            return result.Succeeded;
        }

        public async Task SignOutAsync() 
        {
            await _signInManager.SignOutAsync();
        }
    }
}
