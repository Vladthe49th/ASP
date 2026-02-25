using GuestBook.DAL.Models;

namespace GuestBook.BLL.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByLoginAsync(string login);
        Task<User?> GetByIdAsync(int id);
        Task<int> RegisterAsync(string login, string password);
    }
}