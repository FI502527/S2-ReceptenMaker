using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL
{
    public class RecipeRepository : IRecipeRepository
    {

        public List<Recipe> LoadAllRecipes()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Recipes;", sqlConnection);
            List<Recipe> allRecipes = new List<Recipe>();
            sqlConnection.Open();
            SqlDataReader dataReaderRecipes = command.ExecuteReader();
            if (dataReaderRecipes.HasRows)
            {
                while (dataReaderRecipes.Read())
                {
                    Recipe recipeObject = new Recipe();
                    recipeObject.SetId(dataReaderRecipes.GetInt32(0));
                    recipeObject.SetName(dataReaderRecipes.GetString(1));
                    recipeObject.SetOwner(dataReaderRecipes.GetInt32(2));
                    allRecipes.Add(recipeObject);
                }
            }
            dataReaderRecipes.Close();
            sqlConnection.Close();
            return allRecipes;
        }
        public RecipeIngredientRelation GetRecipeIngredients(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand commandIngredients = new SqlCommand("SELECT * FROM RecipeIngredients WHERE recipeId = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderIngredients = commandIngredients.ExecuteReader();
            RecipeIngredientRelation recipeIngredients = new RecipeIngredientRelation();
            recipeIngredients.SetRecipeId(id);
            if (dataReaderIngredients.HasRows)
            {
                while (dataReaderIngredients.Read())
                {
                    recipeIngredients.AddIngredientId(dataReaderIngredients.GetInt32(1));
                }
                dataReaderIngredients.Close();
            }
            dataReaderIngredients.Close();
            sqlConnection.Close();
            return recipeIngredients;
        }
        public Recipe GetRecipeById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand recipeInfo = new SqlCommand("SELECT * FROM Recipes WHERE id = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderRecipeInfo = recipeInfo.ExecuteReader();
            Recipe recipe = new Recipe();
            if (dataReaderRecipeInfo.HasRows)
            {
                while (dataReaderRecipeInfo.Read())
                {
                    recipe.SetId(dataReaderRecipeInfo.GetInt32(0));
                    recipe.SetName(dataReaderRecipeInfo.GetString(1));
                }
            }
            dataReaderRecipeInfo.Close();
            sqlConnection.Close();
            return recipe;
        }
        public Recipe GetRecipeByName(string name)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand recipeInfo = new SqlCommand($"SELECT * FROM Recipes WHERE name = '{name}';", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderRecipeInfo = recipeInfo.ExecuteReader();
            Recipe recipe = new Recipe();
            if (dataReaderRecipeInfo.HasRows)
            {
                while (dataReaderRecipeInfo.Read())
                {
                    recipe.SetId(dataReaderRecipeInfo.GetInt32(0));
                    recipe.SetName(dataReaderRecipeInfo.GetString(1));
                    recipe.SetDesc(dataReaderRecipeInfo.IsDBNull(3) ? null : dataReaderRecipeInfo.GetString(3));
                }
            }
            dataReaderRecipeInfo.Close();
            sqlConnection.Close();
            return recipe;
        }
        public bool AddNewRecipe(Recipe recipe)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand commandWithDesc = new SqlCommand($"INSERT INTO Recipes (name, ownerId, description) VALUES ('{recipe.Name}', 1, '{recipe.Description}');", sqlConnection);
            SqlCommand commandWithoutDesc = new SqlCommand($"INSERT INTO Recipes (name, ownerId) VALUES ('{recipe.Name}', 1);", sqlConnection);
            sqlConnection.Open();
            int succesful;
            if (recipe.DescriptionCheck())
            {
                succesful = commandWithDesc.ExecuteNonQuery();
            }
            else
            {
                succesful = commandWithoutDesc.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return succesful > 0;
        }
        public bool AddRelationIngredient(int recipeId, int ingredientId)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"INSERT INTO RecipeIngredients (recipeId, ingredientId) VALUES ({recipeId}, {ingredientId});", sqlConnection);
            int succesful;
            sqlConnection.Open();
            succesful = command.ExecuteNonQuery();
            sqlConnection.Close();
            return succesful > 0;
        }
        public bool DeleteRelationIngredient(int recipeId, int ingredientId)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"DELETE FROM RecipeIngredients WHERE recipeId = {recipeId} AND ingredientId = {ingredientId};", sqlConnection);
            int succesful;
            sqlConnection.Open();
            succesful = command.ExecuteNonQuery();
            sqlConnection.Close();
            return succesful > 0;
        }
        public bool EditRecipe(Recipe recipe)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"UPDATE Recipes SET name = '{recipe.Name}', description = '{recipe.Description}' WHERE id = {recipe.Id}", sqlConnection);
            sqlConnection.Open();
            int affectedRows = command.ExecuteNonQuery();
            sqlConnection.Close();
            return affectedRows > 0;
        }
        public bool DeleteRecipe(int id)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"DELETE FROM Recipes WHERE id = {id}", sqlConnection);
            sqlConnection.Open();
            int affectedRows = command.ExecuteNonQuery();
            sqlConnection.Close();
            return affectedRows > 0;
        }
        public bool DeleteAllRelations(int recipeId)
        {
            Connection con = new Connection();
            SqlConnection sqlConnection = con.GetConnection();
            SqlCommand command = new SqlCommand($"DELETE FROM RecipeIngredients WHERE recipeId = {recipeId};", sqlConnection);
            int succesful;
            sqlConnection.Open();
            succesful = command.ExecuteNonQuery();
            sqlConnection.Close();
            return succesful > 0;
        }
    }
}
