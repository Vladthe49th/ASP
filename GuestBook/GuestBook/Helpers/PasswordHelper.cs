using System.Security.Cryptography;
using System.Text;

namespace GuestBook.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateSalt()
        {
            var saltBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            var combined = password + salt;

            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));

            return Convert.ToBase64String(bytes);
        }
    }
}
