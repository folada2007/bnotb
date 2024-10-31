using System.ComponentModel.DataAnnotations;

namespace BooksNotBoobs.DTOs
{
    public class NewBook
    {
        [Required(ErrorMessage = "BookName is required")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author {  get; set; }
        public string Area { get; set; }

        [Range(1,5,ErrorMessage ="Поставьте оценку от 1 до 5")]
        [Required(ErrorMessage = "Point is required")]
        public int Point {  get; set; }
    }
}
