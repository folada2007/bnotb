using BooksNotBoobs.Data;
using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Interfaces;
using BooksNotBoobs.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BooksNotBoobs.Domain.Services
{
    public class BookRepository:IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUrlImgService _UrlImgService;

        public BookRepository(ApplicationDbContext context, IHttpContextAccessor httpContext, IUrlImgService UrlImgService)
        {
            _UrlImgService = UrlImgService;
            _httpContext = httpContext;
            _context = context;
        }

        public async Task<bool> CheckDuplicate(string book) 
        {
            var bookName = await _context.Books.FirstOrDefaultAsync(c => c.BookName == book);

            return bookName != null;
        }

        public async Task<List<Book>> GetAlBookAsync() 
        {
            return await _context.Books.ToListAsync();
        }

        private void CreateField(Book book) 
        {
            book.Area ??= "";
            book.UrlImg = _UrlImgService.GetRandomUrl();
            book.Id = Guid.NewGuid().ToString();
            var UserID = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            book.UserId = UserID;
        }

        public async Task AddBookAsync(Book book) 
        {
            CreateField(book);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(string id) 
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task DeleteBookAsync(string book) 
        {
            var resultFind = await _context.Books.FirstOrDefaultAsync(c => c.BookName == book);
            if (resultFind != null) 
            {
                _context.Books.Remove(resultFind);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> FindByName(string book) 
        {
            return await _context.Books
                .Where(c => c.BookName == book)
                .ToListAsync();
        }

        public async Task<bool> EditBookAsync(Book book, string id) 
        {
            var currentBook = await GetBookById(id);

            if (currentBook == null) 
            {
                return false;
            }
            currentBook.Area = string.IsNullOrEmpty(currentBook.Area) ? "" : book.Area ;
            currentBook.Author = book.Author;
            currentBook.BookName = book.BookName;
            currentBook.Point = book.Point;
            
            _context.Books.Update(currentBook);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
