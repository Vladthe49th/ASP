using GuestBook.BLL.Interfaces;
using GuestBook.DAL.Interfaces;
using GuestBook.DAL.Models;
using System.Security.Cryptography;
using System.Text;

namespace GuestBook.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            var users = await _userRepository.FindAsync(u => u.Login == login);
            return users.FirstOrDefault();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<int> RegisterAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Login cannot be empty");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty");

            var existingUser = await GetByLoginAsync(login);
            if (existingUser != null)
                throw new InvalidOperationException("User already exists");

            var user = new User
            {
                Login = login,
                PasswordHash = HashPassword(password)
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user.Id;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}