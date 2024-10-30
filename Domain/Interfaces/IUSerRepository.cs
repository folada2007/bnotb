using BooksNotBoobs.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BooksNotBoobs.Domain.Interfaces
{
    public interface IUSerRepository
    {
        Task<IdentityResult> AddNewUserAsync(User user,string password);
        Task DeleteUserAsync(string id);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByMailAsync(string mail);

    }
}
