using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;

namespace BooksNotBoobs.Factory
{
    public interface IShelfFactory
    {
        ShelfDto CreateFilter(List<Book> books);
    }
}
