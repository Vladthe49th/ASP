using GuestBook.DAL.Data;
using GuestBook.DAL.Interfaces;
using GuestBook.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DAL.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly GuestBookContext _context;

        public MessageRepository(GuestBookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllWithUsersAsync()
        {
            return await _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }
    }
}
