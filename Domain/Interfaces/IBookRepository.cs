using BooksNotBoobs.Domain.Entities;

namespace BooksNotBoobs.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<Book> GetBookById(string id);
        Task<List<Book>> GetAlBookAsync();
        Task<bool> CheckDuplicate(Book book);

    }
}
