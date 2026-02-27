using Microsoft.EntityFrameworkCore;
using PersonalDiary.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonalDiary.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;

        public AuthService(AppDbContext db)
        {
            _db = db;
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            if (username.Length < 3 || username.Length > 20)
                return false;

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                return false;

            if (password.Length < 8)
                return false;

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).+$"))
                return false;

            // Provjera postoji li već korisnik
            bool exists = await _db.Users.AnyAsync(u => u.Username == username);
            if (exists)
                return false;

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                CreatedAt = DateTime.Now
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return null;

            if (user.PasswordHash == HashPassword(password))
                return user;

            return null;
        }
    }
}
