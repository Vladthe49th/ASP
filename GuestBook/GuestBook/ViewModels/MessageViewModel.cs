using System.ComponentModel.DataAnnotations;

namespace GuestBook.ViewModels
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Повідомлення не може бути порожнім")]
        [MaxLength(1000)]
        public string Text { get; set; } = null!;
    }
}
