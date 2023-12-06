using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestUserRepository : IUserRepository
    {
        public User LoadUserByName(string name)
        {
            User user = new User(1, name, 1, "abc");
            return user;
        }
        public List<User> LoadAllUsers() 
        {
            List<User> users = new List<User>();
            User user1 = new User(1, "tim", 1, "abc");
            User user2 = new User(2, "bas", 2, "def");
            User user3 = new User(3, "bob", 3, "klm");
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            return users;
        }
        public bool AddUser(User newUser)
        {
            return true;
        }
    }
}
