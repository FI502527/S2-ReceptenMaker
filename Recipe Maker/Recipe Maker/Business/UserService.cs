using BusinessObjects;
using DAL;

namespace Business
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public bool LoginCheck(string username, string password)
        {
            UserObject user = userRepository.LoadUserByName(username.ToLower());
            if(password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserObject GetUserByName(string name)
        {
            UserObject user = userRepository.LoadUserByName(name.ToLower());
            return user;
        }
        public List<UserObject> GetAllUsers()
        {
            List<UserObject> users = userRepository.LoadAllUsers();
            return users;
        }
    }
}