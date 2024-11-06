using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Factory
{
    public interface IUpdateFactory
    {
        UpdateDTO CreateUpdateDto(Book? book,NewBook? newBook);
    }
}
