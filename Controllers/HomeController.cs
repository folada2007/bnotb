using Microsoft.AspNetCore.Mvc;

namespace BooksNotBoobs.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
