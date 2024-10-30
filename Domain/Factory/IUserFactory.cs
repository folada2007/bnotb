using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;

namespace BooksNotBoobs.Domain.Factory
{
    public interface IUserFactory
    {
        User CreateUser(NewUser user);
    }
}
