using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BooksNotBoobs.Domain.Interfaces;
using BooksNotBoobs.Domain.Factory;
using BooksNotBoobs.ViewModel;

namespace BooksNotBoobs.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUSerRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private readonly IAuthService _authService;

        public RegistrationController(IUSerRepository userRepository, IUserFactory userFactory, IAuthService authService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckRegistrForm(NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                var user = _userFactory.CreateUser(newUser);
                var result = await _userRepository.AddNewUserAsync(user, newUser.Password);

                if (result.Succeeded)
                {
                    await _authService.SignInAsync(newUser.UserEmail, newUser.Password);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View("Index", newUser);
        }
    }
}
