using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Domain.Factory
{
    public class UserFactory:IUserFactory
    {
        public User CreateUser(NewUser user) 
        {
            var createUser = new User 
            {
                UserName = user.UserName,
                Email = user.UserEmail,
            };
            return createUser;
        }
    }
}
