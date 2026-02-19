using GuestBook.Data;
using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Repositories
{
    public class Repository : IRepository
    {
        private readonly GuestBookContext _context;

        public Repository(GuestBookContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
    }
}
