using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft;

namespace DAL
{
    public class UserRepository
    {
        public List<UserObject> LoadAllUsers()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Users;", sqlConnection);
            List<UserObject> allUsers = new List<UserObject>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    UserObject userObject = new UserObject();
                    userObject.SetUserId(DataReader.GetInt32(0));
                    userObject.SetUsername(DataReader.GetString(1));
                    userObject.SetRoleId(DataReader.GetInt32(2));
                    allUsers.Add(userObject);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return allUsers;
        }
        public UserObject LoadUserByName(string name)
        {
            UserObject userObject = new UserObject();
            Connection con = new();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE username = '{name}';", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    
                    userObject.SetUserId(DataReader.GetInt32(0));
                    userObject.SetUsername(DataReader.GetString(1));
                    userObject.SetRoleId(DataReader.GetInt32(2));
                    userObject.SetPassword(DataReader.GetString(3));
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return userObject;
        }
    }
}
