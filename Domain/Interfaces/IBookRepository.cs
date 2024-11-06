using BooksNotBoobs.Domain.Entities;

namespace BooksNotBoobs.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(string book);
        Task<Book> GetBookById(string id);
        Task<List<Book>> GetAlBookAsync();
        Task<bool> CheckDuplicate(string book);
        Task<List<Book>> FindByName(string book);
        Task<bool> EditBookAsync(Book book,string id);
    }
}
