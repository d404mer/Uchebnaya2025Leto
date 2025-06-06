using Microsoft.EntityFrameworkCore;
using System.Linq;
using UCHEBKA.Models;
using System.IO;

namespace UCHEBKA.Repos
{
    public class UserRepository
    {
        private readonly UchebnayaLeto2025Context _db;

        public UserRepository(UchebnayaLeto2025Context db)
        {
            _db = db;
        }

        public User Auth(int userId, string password)
        {
            return _db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.FkRole)
                .FirstOrDefault(u => u.UserId == userId && u.UserPassword == password);
        }

        public void Logout()
        {
            File.WriteAllText("CurrUser.txt", string.Empty);
        }
        public void SaveCurrentUser(int userId, string password)
        {
            File.WriteAllText("CurrUser.txt", $"{userId}|{password}");
        }

        public (int userId, string password)? GetCurrentUser()
        {
            if (!File.Exists("CurrUser.txt"))
                return null;

            var content = File.ReadAllText("CurrUser.txt");
            if (string.IsNullOrWhiteSpace(content))
                return null;

            var parts = content.Split('|');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int userId))
                return null;

            return (userId, parts[1]);
        }

        public string GetUserRole(long userId)
        {
            return _db.UserRoles
                .Include(ur => ur.FkRole)
                .Where(ur => ur.FkUserId == userId)
                .Select(ur => ur.FkRole.RoleName)
                .FirstOrDefault();
        }
    }
}
