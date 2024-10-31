using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksNotBoobs.Domain.Entities
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Area { get; set; }
        public int Point { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
