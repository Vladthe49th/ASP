using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

       
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
