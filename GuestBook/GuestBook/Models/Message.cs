using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
