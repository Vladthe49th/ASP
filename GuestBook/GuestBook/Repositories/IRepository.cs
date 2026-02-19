using GuestBook.Models;

namespace GuestBook.Repositories
{
    public interface IRepository
    {
        Task<List<Message>> GetAllMessagesAsync();
        Task AddMessageAsync(Message message);
    }
}
