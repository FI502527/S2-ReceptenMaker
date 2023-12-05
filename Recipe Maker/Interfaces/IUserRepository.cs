using BusinessObjects;

namespace Interfaces
{
    public interface IUserRepository
    {
        public List<User> LoadAllUsers();
        public User LoadUserByName(string name);
        public bool AddUser(User newUser);
    }
}