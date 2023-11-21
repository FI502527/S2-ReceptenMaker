using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                    SqlCommand commandIngredients = new SqlCommand("SELECT * FROM RecipeIngredients WHERE recipeId = " + recipeObject.Id + ";", sqlConnection);
                    SqlDataReader dataReaderIngredients = commandIngredients.ExecuteReader();
                    if (dataReaderIngredients.HasRows)
                    {
                        while(dataReaderIngredients.Read())
                        {
                            SqlCommand ingredientInfo = new SqlCommand("SELECT * FROM Ingredients WHERE id = " + dataReaderIngredients.GetInt32(1) + ";");
                            SqlDataReader dataReaderIngredientInfo = ingredientInfo.ExecuteReader();
                            if(dataReaderIngredientInfo.HasRows)
                            {
                                while (dataReaderIngredientInfo.Read())
                                {
                                    IngredientObject ingredient = new IngredientObject();
                                    ingredient.SetId(dataReaderIngredientInfo.GetInt32(0));
                                    ingredient.SetName(dataReaderIngredientInfo.GetString(1));
                                    ingredient.SetDescription(dataReaderIngredientInfo.GetString(2));
                                    recipeObject.AddIngredients(ingredient);
                                }
                                dataReaderIngredientInfo.Close();
                            }
                        }
                        dataReaderIngredients.Close();
                    }
                    allRecipes.Add(recipeObject);
                }
            }
            dataReaderRecipes.Close();
            sqlConnection.Close();
            return allRecipes;
        }
    }
}
