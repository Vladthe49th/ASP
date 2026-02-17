using GuestBook.Data;
using GuestBook.Helpers;
using GuestBook.Models;
using GuestBook.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Services
{
    public class UserService : IUserService
    {
        private readonly GuestBookContext _context;

        public UserService(GuestBookContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAsync(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task RegisterAsync(string login, string password)
        {
            var salt = PasswordHelper.GenerateSalt();
            var hash = PasswordHelper.HashPassword(password, salt);

            var user = new User
            {
                Login = login,
                PasswordHash = hash,
                Salt = salt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> AuthenticateAsync(string login, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login);

            if (user == null)
                return null;

            var hash = PasswordHelper.HashPassword(password, user.Salt);

            return hash == user.PasswordHash ? user : null;
        }
    }
}
