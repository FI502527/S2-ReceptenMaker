using BusinessObjects;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IngredientRepository : IIngredientRepository
    {
        public List<Ingredient> LoadAllIngredients()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Ingredients;", sqlConnection);
            List<Ingredient> allIngredients = new List<Ingredient>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.SetId(DataReader.GetInt32(0));
                    ingredient.SetName(DataReader.GetString(1));
                    ingredient.SetDescription(DataReader.IsDBNull(2) ? null : DataReader.GetString(2));
                    allIngredients.Add(ingredient);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return allIngredients;
        }
        public Ingredient LoadIngredientById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Ingredients WHERE id = {id};", sqlConnection);
            Ingredient ingredient = new Ingredient();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    ingredient.SetId(DataReader.GetInt32(0));
                    ingredient.SetName(DataReader.GetString(1));
                    ingredient.SetDescription(DataReader.IsDBNull(2) ? null : DataReader.GetString(2));
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return ingredient;
        }
        public bool AddIngredient(Ingredient ingredient)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand commandWithDesc = new SqlCommand($"INSERT INTO Ingredients (name, description) VALUES ('{ingredient.Name}', '{ingredient.Description}');", sqlConnection);
            SqlCommand commandWithoutDesc = new SqlCommand($"INSERT INTO Ingredients (name) VALUES ('{ingredient.Name}');", sqlConnection);
            sqlConnection.Open();
            int succesful;
            if (ingredient.DescriptionCheck())
            {
                succesful = commandWithDesc.ExecuteNonQuery();
            }
            else
            {
                succesful = commandWithoutDesc.ExecuteNonQuery();
            }
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
        public bool UpdateIngredient(Ingredient ingredient)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand commandWithDesc = new SqlCommand($"UPDATE Ingredients SET name = '{ingredient.Name}' WHERE id = {ingredient.Id};", sqlConnection);
            SqlCommand commandWithoutDesc = new SqlCommand($"UPDATE Ingredients SET name = '{ingredient.Name}', description = '{ingredient.Description}' WHERE id = {ingredient.Id};", sqlConnection);
            sqlConnection.Open();
            int succesful;
            if (ingredient.DescriptionCheck())
            {
                succesful = commandWithDesc.ExecuteNonQuery();
            }
            else
            {
                succesful = commandWithoutDesc.ExecuteNonQuery();
            }
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
