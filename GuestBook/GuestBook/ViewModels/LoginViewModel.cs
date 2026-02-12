using System.ComponentModel.DataAnnotations;

namespace GuestBook.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть логін")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
