namespace BusinessObjects
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public int RoleId { get; private set; }

        public User(int id, string username, int roleId)
        {
            Id = id;
            Username = username;
            RoleId = roleId;
        }

        public User(string username, int roleId)
        {
            Username = username;
            RoleId = roleId;
        }
    }
}