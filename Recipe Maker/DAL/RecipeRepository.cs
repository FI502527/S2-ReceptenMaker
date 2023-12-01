using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RecipeRepository
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
                    RecipeIngredientRelation recipeIngredients = GetRecipeIngredients(recipeObject.Id);
                    foreach(int ingredientId in recipeIngredients.IngredientId)
                    {
                        Ingredient ingredient = GetIngredientById(ingredientId);
                        recipeObject.AddIngredients(ingredient);
                    }
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
            SqlCommand recipeInfo = new SqlCommand("SELECT * FROM Recipe WHERE id = " + id + ";", sqlConnection);
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
        public Ingredient GetIngredientById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand ingredientInfo = new SqlCommand("SELECT * FROM Ingredients WHERE id = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderIngredientInfo = ingredientInfo.ExecuteReader();
            Ingredient ingredient = new Ingredient();
            if (dataReaderIngredientInfo.HasRows)
            {
                while (dataReaderIngredientInfo.Read())
                {
                    ingredient.SetId(dataReaderIngredientInfo.GetInt32(0));
                    ingredient.SetName(dataReaderIngredientInfo.GetString(1));
                    ingredient.SetDescription(dataReaderIngredientInfo.IsDBNull(2) ? null : dataReaderIngredientInfo.GetString(3));
                }
            }
            dataReaderIngredientInfo.Close();
            sqlConnection.Close();
            return ingredient;
        }

    }
}
