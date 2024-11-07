using Microsoft.AspNetCore.Mvc;
using BooksNotBoobs.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BooksNotBoobs.ViewModel;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Interfaces;

namespace BooksNotBoobs.Controllers
{
    [Authorize]
    public class BookshelfController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactoryService _bookFactoryService;

        public BookshelfController(IBookRepository bookRepository, IBookFactoryService bookFactoryService)
        {
            _bookFactoryService = bookFactoryService;
            _bookRepository = bookRepository;
        }

        public IActionResult SetBooks()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckBookForm(NewBook book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookFactoryService.CreateBook(book);
                var Copy = await _bookRepository.CheckDuplicate(result.BookName);
                if (Copy)
                {
                    ModelState.AddModelError(string.Empty, "Такая книга уже есть");
                    return View("SetBooks", book);
                }
                await _bookRepository.AddBookAsync(result);
            }
            return View("SetBooks", book);
        }

        public async Task<IActionResult> Index(string? Search)
        {
            var AllBook = await _bookRepository.GetAlBookAsync();
            var SearchResult = await _bookRepository.FindByName(Search);
            var filter = string.IsNullOrEmpty(Search) ? AllBook : SearchResult;
            var result = _bookFactoryService.CreateFilter(filter);
            return View(result);
        }

        public IActionResult Remove() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(BookNameDTO bookNameDTO) 
        {
            if (ModelState.IsValid) 
            {
                var createdBook = _bookFactoryService.CreateBookNameOnly(bookNameDTO);
                await _bookRepository.DeleteBookAsync(createdBook.BookName);
                return RedirectToAction("Index");
            }
            return View(bookNameDTO);
        }

        public async Task<IActionResult> UpdateBook(string Id)
        {
            HttpContext.Session.SetString("Book_id", Id);
            var book = await _bookRepository.GetBookById(Id);
            var result = _bookFactoryService.CreateUpdateDto(book,null);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(NewBook newBook) 
        {
            var bookID = HttpContext.Session.GetString("Book_id");
            var book = _bookFactoryService.CreateBook(newBook);
            var result = _bookFactoryService.CreateUpdateDto(book, null);
            if (ModelState.IsValid) 
            {
                var Updater = await _bookRepository.EditBookAsync(book, bookID);
                if (Updater) 
                {
                    return RedirectToAction("Index");
                }
            }
            return View(result);
        }

    }
}
