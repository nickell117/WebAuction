using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class EfUserRepository : IUserRepository
    {
        private AppDbContext context;

        public EfUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User AddUser(User user)
        {
            string password = Hash(user);
            user.Password = password;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            return context.Users.OrderBy(u => u.Email);
        }

        public User GetUserByEmail(string email)
        {
            return context.Users
               .FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User UpdateUser(User user)
        {
            User userToUpdate = GetUserById(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                context.SaveChanges();
            }
            return userToUpdate;
        }

        public bool DeleteUser(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete == null)
            {
                return false;
            }
            context.Users.Remove(userToDelete);
            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(User user)
        {
            return DeleteUser(user.Id);
        }
        private string Hash(User user)
        {
            byte[] username = Encoding.ASCII.GetBytes(user.Email);
            byte[] password = Encoding.ASCII.GetBytes(user.Password);

            int length = Math.Max(username.Length,
                                  password.Length);
            byte[] saltedBytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                saltedBytes[i] =
                   (byte)(username[i % username.Length] ^ password[i % password.Length]);
            }

            SHA512 hasher = SHA512.Create();
            byte[] hash = hasher.ComputeHash(saltedBytes);
            return BitConverter.ToString(hash)
                               .Replace("-", string.Empty);
        }

        public bool Login(User user)
        {
            throw new NotImplementedException();
        }
    }

}
