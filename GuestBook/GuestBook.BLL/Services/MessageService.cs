using GuestBook.BLL.Interfaces;
using GuestBook.DAL.Interfaces;
using GuestBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> GetAllMessagesAsync()
        {
            return await _messageRepository.GetAllWithUsersAsync();
        }

        public async Task AddMessageAsync(string text, int userId)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Message cannot be empty");

            var message = new Message
            {
                Text = text,
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
        }
    }
}
