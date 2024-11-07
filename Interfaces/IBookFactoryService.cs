using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Interfaces
{
    public interface IBookFactoryService
    {
        Book CreateBook(NewBook newBook);
        Book CreateBookNameOnly(BookNameDTO newBook);
        ShelfDto CreateFilter(List<Book> books);
        UpdateDTO CreateUpdateDto(Book? book, NewBook? newBook);
    }
}
