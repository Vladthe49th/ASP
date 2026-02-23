using GuestBook.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.DAL.Data
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}