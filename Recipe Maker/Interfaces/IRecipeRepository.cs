using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRecipeRepository
    {
        public List<Recipe> LoadAllRecipes();
        public RecipeIngredientRelation GetRecipeIngredients(int id);
        public Recipe GetRecipeById(int id);
        public Recipe GetRecipeByName(string name);
        public bool AddNewRecipe(Recipe recipe);
        public bool AddRelationIngredient(int recipeId, int ingredientId);
        public bool DeleteRelationIngredient(int recipeId, int ingredientId);
        public bool EditRecipe(Recipe recipe);
        public bool DeleteRecipe(int id);
        public bool DeleteAllRelations(int recipeId);
    }
}
