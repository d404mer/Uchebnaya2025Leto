using Microsoft.EntityFrameworkCore;
using System.Linq;
using UCHEBKA.Models;
using System.IO;

namespace UCHEBKA.Repos
{
    public class UserRepository
    {
        private readonly UchebnayaLeto2025Context _db;
        public const string BaseImagePath = "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Users\\";


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

        public string GetUserSex(long userId)
        {
            return _db.UserSexes
                .Where(us => us.FkUserId == userId)
                .Select(us => us.FkSex.SexName)
                .FirstOrDefault();
        }

        public User GetUserById(long userId)
        {
            return _db.Users
                .Include(u => u.UserSexes)
                .ThenInclude(us => us.FkSex)
                .FirstOrDefault(u => u.UserId == userId);
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public List<Sex> GetAllSexes()
        {
            return _db.Sexes.ToList();
        }

        public void UpdateUserSex(long userId, long sexId)
        {
            var userSex = _db.UserSexes.FirstOrDefault(us => us.FkUserId == userId);

            if (userSex != null)
            {
                userSex.FkSexId = sexId;
            }
            else
            {
                _db.UserSexes.Add(new UserSex
                {
                    FkUserId = userId,
                    FkSexId = sexId
                });
            }

            _db.SaveChanges();
        }

        public bool UpdatePassword(long userId, string currentPassword, string newPassword)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == userId && u.UserPassword == currentPassword);

            if (user != null)
            {
                user.UserPassword = newPassword;
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        public User GetCurrentUserData()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null) return null;

            return GetUserById(currentUser.Value.userId);
        }

        public string GetFullImagePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Users\\2.jpeg";

            var fullPath = $"{BaseImagePath}{fileName}";

            if (!System.IO.File.Exists(fullPath))
            {
                Console.WriteLine($"Image not found: {fullPath}");
                return "D:\\CIT KAI\\Uchebnaya2025Leto\\! Proj\\UCHEBKA\\UCHEBKA\\Images\\Users\\1.jpeg";
            }

            return fullPath;
        }

        public long GetNextUserId()
        {
            return _db.Users.Any() ? _db.Users.Max(u => u.UserId) + 1 : 1;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void AddUserRole(long userId, long roleId)
        {
            _db.UserRoles.Add(new UserRole
            {
                FkUserId = userId,
                FkRoleId = roleId
            });
            _db.SaveChanges();
        }

        public void AddUserEvent(long userId, long eventId)
        {
            _db.UserEvents.Add(new UserEvent
            {
                FkUserId = userId,
                FkEventId = eventId
            });
            _db.SaveChanges();
        }

    }
}