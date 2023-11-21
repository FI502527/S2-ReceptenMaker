using Business;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_Maker.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService _recipeService;
        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public IActionResult Index()
        {
            List<RecipeObject> recipes = _recipeService.GetAllRecipes();
            return View(recipes);
        }
    }
}
