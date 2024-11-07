using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Factory;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Factory;
using BooksNotBoobs.Interfaces;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Services
{
    public class BookFactoryService: IBookFactoryService
    {
        private readonly IBookFactory _bookFactory;
        private readonly IShelfFactory _shelfFactory;
        private readonly IUpdateFactory _updateFactory;

        public BookFactoryService(IBookFactory bookFactory, IShelfFactory shelfFactory, IUpdateFactory updateFactory)
        {
            _bookFactory = bookFactory;
            _shelfFactory = shelfFactory;
            _updateFactory = updateFactory;
        }

        public UpdateDTO CreateUpdateDto(Book? book, NewBook? newBook) 
        {
            return _updateFactory.CreateUpdateDto(book,newBook);
        }

        public ShelfDto CreateFilter(List<Book> books) 
        {
           return _shelfFactory.CreateFilter(books);
        }

        public Book CreateBookNameOnly(BookNameDTO newBook) 
        {
            return _bookFactory.CreateBookNameOnly(newBook);
        }

        public Book CreateBook(NewBook newBook) 
        {
            return _bookFactory.CreateBook(newBook);
        }
    }
}
