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
        public bool AddNewRecipe(Recipe recipe)
        {
            bool recipeStatus = recipeRepository.AddNewRecipe(recipe);
            int receptId = GetRecipeByName(recipe.Name).Id;
            bool status = true;
            foreach(Ingredient ingredient in recipe.Ingredients)
            {
                status = recipeRepository.AddRelationIngredient(receptId, ingredient.Id);
            }
            return status;
        }
        public Recipe GetRecipeByName(string name)
        {
            Recipe recipe = recipeRepository.GetRecipeByName(name);
            RecipeIngredientRelation recipeIngredients = recipeRepository.GetRecipeIngredients(recipe.Id);
            List<Ingredient> ingredientsRecipe = GetIngredientsRecipe(recipeIngredients);
            recipe.SetIngredients(ingredientsRecipe);
            return recipe;
        }
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = recipeRepository.GetRecipeById(id);
            RecipeIngredientRelation recipeIngredients = recipeRepository.GetRecipeIngredients(id);
            List<Ingredient> ingredientsRecipe = GetIngredientsRecipe(recipeIngredients);
            recipe.SetIngredients(ingredientsRecipe);
            return recipe;
        }
        public bool EditRecipe(Recipe recipe)
        {
            RecipeIngredientRelation oldIngredients = recipeRepository.GetRecipeIngredients(recipe.Id);
            bool check1 = true;
            List<int> newIngredientIds = new List<int>();
            foreach(Ingredient ingredient in recipe.Ingredients)
            {
                newIngredientIds.Add(ingredient.Id);
                if(!oldIngredients.IngredientId.Contains(ingredient.Id))
                {
                    check1 = recipeRepository.AddRelationIngredient(recipe.Id, ingredient.Id);
                }
            }
            bool check2 = true;
            foreach(int id in oldIngredients.IngredientId)
            {
                if (!newIngredientIds.Contains(id))
                {
                    check2 = recipeRepository.DeleteRelationIngredient(recipe.Id, id);
                }
            }
            bool check3 = recipeRepository.EditRecipe(recipe);
            if (check1 && check2 && check3) return true; 
            else return false;
        }
        public bool DeleteRecipe(int id)
        {
            bool check1 = recipeRepository.DeleteAllRelations(id);
            bool check2 = recipeRepository.DeleteRecipe(id);
            if(check1 && check2) return true;
            else return false;
        }
    }
}
