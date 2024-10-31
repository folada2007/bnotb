using Microsoft.AspNetCore.Mvc;
using BooksNotBoobs.DTOs;
using BooksNotBoobs.Domain.Interfaces;
using BooksNotBoobs.Domain.Factory;

namespace BooksNotBoobs.Controllers.Bookshelf
{
    public class BookshelfController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactory _bookFactory;

        public BookshelfController(IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookFactory = bookFactory;
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
                var result = _bookFactory.CreateBook(book);
                var trueORno = await _bookRepository.CheckDuplicate(result);
                if (trueORno) 
                {
                    ModelState.AddModelError(string.Empty,"Такая книга уже есть");
                    return View("SetBooks",book);
                }
                await _bookRepository.AddBookAsync(result);
            }
            return View("SetBooks", book);
        }

        public async Task<IActionResult> Index() 
        {
            var result = await _bookRepository.GetAlBookAsync();
            return View(result);
        }

    }
}
