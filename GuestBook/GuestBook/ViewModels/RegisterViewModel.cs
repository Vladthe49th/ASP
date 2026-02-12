using System.ComponentModel.DataAnnotations;

namespace GuestBook.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Логін обовʼязковий")]
        [StringLength(50)]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Пароль обовʼязковий")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
