using GuestBook.Models;

namespace GuestBook.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string login);
        Task RegisterAsync(string login, string password);
        Task<User?> AuthenticateAsync(string login, string password);
    }
}
