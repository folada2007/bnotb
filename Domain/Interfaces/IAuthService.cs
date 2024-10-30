namespace BooksNotBoobs.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string mail,string password);
        Task SignOutAsync();
    }
}
