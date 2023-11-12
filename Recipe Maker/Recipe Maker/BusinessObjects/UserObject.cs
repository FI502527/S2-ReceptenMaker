namespace BusinessObjects
{
    public class UserObject
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public int RoleId { get; private set; }

        public UserObject(int id, string username, int roleId)
        {
            Id = id;
            Username = username;
            RoleId = roleId;
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
    }
}