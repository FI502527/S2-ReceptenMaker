using Business;
using BusinessObjects;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_Maker.Controllers
{
    public class RecipeController : Controller
    {
        RecipeService recipeService;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            recipeService = new RecipeService(recipeRepository);
        }
        public IActionResult Index()
        {
            List<Recipe> recipes = recipeService.GetAllRecipes();
            return View(recipes);
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
