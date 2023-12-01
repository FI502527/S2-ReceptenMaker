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
        public List<RecipeObject> LoadAllRecipes()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM Recipes;", sqlConnection);
            List<RecipeObject> allRecipes = new List<RecipeObject>();
            sqlConnection.Open();
            SqlDataReader dataReaderRecipes = command.ExecuteReader();
            if (dataReaderRecipes.HasRows)
            {
                while (dataReaderRecipes.Read())
                {
                    RecipeObject recipeObject = new RecipeObject();
                    recipeObject.SetId(dataReaderRecipes.GetInt32(0));
                    recipeObject.SetName(dataReaderRecipes.GetString(1));
                    recipeObject.SetOwner(dataReaderRecipes.GetInt32(2));
                    RecipeIngredientsObject recipeIngredients = GetRecipeIngredients(recipeObject.Id);
                    foreach(int ingredientId in recipeIngredients.IngredientId)
                    {
                        IngredientObject ingredient = GetIngredientById(ingredientId);
                        recipeObject.AddIngredients(ingredient);
                    }
                    allRecipes.Add(recipeObject);
                }
            }
            dataReaderRecipes.Close();
            sqlConnection.Close();
            return allRecipes;
        }
        public RecipeIngredientsObject GetRecipeIngredients(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand commandIngredients = new SqlCommand("SELECT * FROM RecipeIngredients WHERE recipeId = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderIngredients = commandIngredients.ExecuteReader();
            RecipeIngredientsObject recipeIngredients = new RecipeIngredientsObject();
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
        public RecipeObject GetRecipeById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand recipeInfo = new SqlCommand("SELECT * FROM Recipe WHERE id = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderRecipeInfo = recipeInfo.ExecuteReader();
            RecipeObject recipe = new RecipeObject();
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
        public IngredientObject GetIngredientById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand ingredientInfo = new SqlCommand("SELECT * FROM Ingredients WHERE id = " + id + ";", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReaderIngredientInfo = ingredientInfo.ExecuteReader();
            IngredientObject ingredient = new IngredientObject();
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
