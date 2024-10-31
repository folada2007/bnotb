using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;

namespace BooksNotBoobs.Domain.Factory
{
    public interface IBookFactory
    {
        Book CreateBook(NewBook book);
    }
}
