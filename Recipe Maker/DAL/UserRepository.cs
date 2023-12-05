using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessObjects;
using Microsoft;
using Interfaces;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        public List<User> LoadAllUsers()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Users;", sqlConnection);
            List<User> allUsers = new List<User>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    User userObject = new User();
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
        public User LoadUserByName(string name)
        {
            User user = new User();
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE username = '{name}';", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {

                    user.SetUserId(DataReader.GetInt32(0));
                    user.SetUsername(DataReader.GetString(1));
                    user.SetRoleId(DataReader.GetInt32(2));
                    user.SetPassword(DataReader.GetString(3));
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return user;
        }
        public bool AddUser(User newUser)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"INSERT INTO Users (username, roleId, password) VALUES ('{newUser.Username}', 2, '{newUser.Password}');", sqlConnection);
            sqlConnection.Open();
            int succesful = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (succesful > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
