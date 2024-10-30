using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BooksNotBoobs.Domain.Services
{
    public class UserRepository:IUSerRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserByMailAsync(string mail) 
        {
           return await _userManager.FindByEmailAsync(mail);

        }
        public async Task<IdentityResult> AddNewUserAsync(User user, string password) 
        {
           return await _userManager.CreateAsync(user,password);
        }

        public async Task DeleteUserAsync(string id) 
        {
            var user = await GetUserByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public Task<User> GetUserByIdAsync(string id) 
        {
            return _userManager.FindByIdAsync(id);
        }
    }
}
