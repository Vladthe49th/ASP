using GuestBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.BLL.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllMessagesAsync();
        Task AddMessageAsync(string text, int userId);
    }
}
