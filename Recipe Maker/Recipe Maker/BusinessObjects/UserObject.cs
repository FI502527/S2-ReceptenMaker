namespace BusinessObjects
{
    public class UserObject
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public int RoleId { get; private set; }
        public string Password { get; private set; }

        public UserObject(int id, string username, int roleId, string password)
        {
            Id = id;
            Username = username;
            RoleId = roleId;
            Password = password;
        }

        public UserObject(string username, int roleId)
        {
            Username = username;
            RoleId = roleId;
        }
        public UserObject()
        {

        }
        public void SetUserId(int userId)
        {
            Id = userId;
        }
        public void SetUsername(string username)
        {
            Username = username;
        }
        public void SetRoleId(int roleId)
        {
            RoleId = roleId;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}