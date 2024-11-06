using System.ComponentModel.DataAnnotations;

namespace BooksNotBoobs.ViewModel
{
    public class NewUser
    {
        [Required(ErrorMessage = "Введите имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите почту")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
