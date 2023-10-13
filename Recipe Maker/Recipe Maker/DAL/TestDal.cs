using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessObjects;

namespace DAL
{
    public class TestDal
    {
        private string _connectionString;

        public TestDal()
        {
            this._connectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=RecipeMaker;Integrated Security=SSPI;";
        }

        public List<User> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    //Command initilization
                    string query = "SELECT * FROM Users";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();

                        while (reader.Read())
                        {
                            int userId = (int)reader["id"];
                            string username = reader["username"].ToString();
                            int roleId = (int)reader["roleId"];
                            User user = new User(userId, username, roleId);
                            users.Add(user);
                        }
                        return users;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}