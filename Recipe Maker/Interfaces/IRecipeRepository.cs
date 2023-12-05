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
        public Ingredient GetIngredientById(int id);
    }
}
