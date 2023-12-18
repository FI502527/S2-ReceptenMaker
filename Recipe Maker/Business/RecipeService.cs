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
        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> allRecipes = recipeRepository.LoadAllRecipes();
            return allRecipes;
        }
    }
}
