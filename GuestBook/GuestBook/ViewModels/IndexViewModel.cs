using GuestBook.Models;

namespace GuestBook.ViewModels
{
    public class IndexViewModel
    {
        public List<Message> Messages { get; set; } = new();
        public string? CurrentUserLogin { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
