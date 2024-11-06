using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Interfaces;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Domain.Factory
{
    public interface IBookFactory
    {
        Book CreateBook(NewBook book);
        Book CreateBookNameOnly(BookNameDTO bookName);
    }
}
