using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.DTOs
{
    public class UpdateDTO
    {
        public Book Book {  get; set; } 
        public NewBook NewBook { get; set; }
    }
}
