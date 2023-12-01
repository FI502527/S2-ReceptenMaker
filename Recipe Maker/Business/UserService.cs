using BusinessObjects;
using DAL;

namespace Business
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public bool LoginCheck(string username, string password)
        {
            User user = userRepository.LoadUserByName(username.ToLower());
            return password == user.Password;
        }
        public User GetUserByName(string name)
        {
            User user = userRepository.LoadUserByName(name.ToLower());
            return user;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = userRepository.LoadAllUsers();
            return users;
        }
        public bool AddUser(User newUser)
        {
            return userRepository.AddUser(newUser);
        }
    }
}