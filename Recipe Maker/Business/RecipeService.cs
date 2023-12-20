using BusinessObjects;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IIngredientRepository ingredientRepository;
        public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }
        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> allRecipesWithoutIngredients = recipeRepository.LoadAllRecipes();
            List<Recipe> updatedRecipeList = new List<Recipe>();
            foreach(Recipe recipe in allRecipesWithoutIngredients)
            {
                RecipeIngredientRelation recipeIngredients = recipeRepository.GetRecipeIngredients(recipe.Id);
                List<Ingredient> ingredientsRecipe = GetIngredientsRecipe(recipeIngredients);
                recipe.SetIngredients(ingredientsRecipe);
                updatedRecipeList.Add(recipe);
            }
            return updatedRecipeList;
        }
        public List<Ingredient> GetIngredientsRecipe(RecipeIngredientRelation relations)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (int ingredientId in relations.IngredientId)
            {
                Ingredient ingredient = ingredientRepository.LoadIngredientById(ingredientId);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
    }
}
