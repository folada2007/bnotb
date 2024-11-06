using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Factory
{
    public class UpdateFactory:IUpdateFactory
    {
        public UpdateDTO CreateUpdateDto(Book? book, NewBook? newBook) 
        {
            return new UpdateDTO
            {
                Book = book,
                NewBook = newBook
            };
        }
    }
}
