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
        public UserObject LoadAllUsers()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Users;", sqlConnection);
            UserObject userObject = new UserObject();
            //List<UserObject> allUsers = new List<UserObject>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    userObject.SetUserId(DataReader.GetInt32(0));
                    userObject.SetUsername(DataReader.GetString(1));
                    userObject.SetRoleId(DataReader.GetInt32(2));
                    //allUsers.Add(userObject);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return userObject;
        }
    }
}
