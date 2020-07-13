using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public interface IUserRepository
    {
        public User AddUser(User user);

        public IQueryable<User> GetAllUsers();

        public User GetUserByEmail(string email);

        public User GetUserById(int id);

        public User UpdateUser(User user);

        public bool DeleteUser(int id);

        public bool DeleteUser(User user);
    }
}
