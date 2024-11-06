using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Interfaces;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Domain.Factory
{
    public class BookFactory:IBookFactory
    {
        public Book CreateBook(NewBook book)
        {
            return new Book 
            {
                BookName = book.BookName,
                Author = book.Author,
                Area = book.Area,
                Point = book.Point
            };
        }

        public Book CreateBookNameOnly(BookNameDTO bookName)
        {
            return new Book
            {
                BookName = bookName.BookName,
            };
        }
    }
}
