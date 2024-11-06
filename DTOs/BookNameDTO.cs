
using System.ComponentModel.DataAnnotations;

namespace BooksNotBoobs.DTOs
{
    public class BookNameDTO
    {
        [Required(ErrorMessage = "Is Required")]
        public string BookName { get; set; }
    }
}
