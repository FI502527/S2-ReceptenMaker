using BusinessObjects;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RecipeService
    {
        RecipeRepository recipeRepository = new RecipeRepository();
        public List<RecipeObject> GetAllRecipes()
        {
            List<RecipeObject> allRecipes = recipeRepository.LoadAllRecipes();
            return allRecipes;
        }
    }
}
