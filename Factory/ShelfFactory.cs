using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.DTOs;

namespace BooksNotBoobs.Factory
{
    public class ShelfFactory:IShelfFactory
    {
        public ShelfDto CreateFilter(List<Book> books) 
        {
            return new ShelfDto
            {
                books = books
            };
        }
    }
}
