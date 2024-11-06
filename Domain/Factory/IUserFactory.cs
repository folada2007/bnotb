using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Domain.Factory
{
    public interface IUserFactory
    {
        User CreateUser(NewUser user);
    }
}
