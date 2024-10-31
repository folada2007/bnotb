using BooksNotBoobs.Data;
using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BooksNotBoobs.Domain.Services
{
    public class BookRepository:IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public BookRepository(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public async Task<bool> CheckDuplicate(Book book) 
        {
            var bookName = await _context.Books.FirstOrDefaultAsync(c => c.BookName == book.BookName);

            return bookName != null;
        }

        public async Task<List<Book>> GetAlBookAsync() 
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddBookAsync(Book book) 
        {
            book.Id = Guid.NewGuid().ToString();
            var UserID = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            book.UserId = UserID;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(string id) 
        {
            var resultFind = await _context.Books.FindAsync(id);
            return resultFind;
        }

        public async Task DeleteBookAsync(Book book) 
        {
            var resultFind = await GetBookById(book.Id);
            if (resultFind != null) 
            {
                _context.Books.Remove(resultFind);
                await _context.SaveChangesAsync();
            }
        }
    }
}
