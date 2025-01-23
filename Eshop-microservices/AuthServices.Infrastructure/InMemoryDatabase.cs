using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Entities;

namespace AuthServices.Infrastructure
{
    public class InMemoryDatabase
    {
        private readonly List<User> _users = new();
        public InMemoryDatabase()
        {
            // Initialize the in-memory database with some default users
            _users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "New USer",
                    Email = "New@pepcus.com",
                    FullName = "New pepcus"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "DemoUser",
                    Email = "Demosuer@Pepcus.com",
                    FullName = "Demo User"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "Shubham",
                    Email = "shubham@pepcus.com",
                    FullName = "Shubham Prasad"
                }
            };
        }
        public void AddUser(User user) => _users.Add(user);

        public User GetUserById(Guid id) => _users.FirstOrDefault(u => u.Id == id);

        public IEnumerable<User> GetAllUsers() => _users;

        public bool UpdateUser(User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user == null) return false;

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.FullName = updatedUser.FullName;
            return true;
        }

        public bool DeleteUser(Guid id) => _users.RemoveAll(u => u.Id == id) > 0;
    }
}
