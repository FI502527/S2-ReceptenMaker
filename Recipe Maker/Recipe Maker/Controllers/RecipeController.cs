using Business;
using BusinessObjects;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_Maker.Controllers
{
    public class RecipeController : Controller
    {
        RecipeService recipeService;
        IngredientService ingredientService;
        public RecipeController(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            recipeService = new RecipeService(recipeRepository);
            ingredientService = new IngredientService(ingredientRepository);
        }
        public IActionResult Index()
        {
            List<Recipe> recipes = recipeService.GetAllRecipes();
            return View(recipes);
        }
        public IActionResult Add()
        {
            List<Ingredient> ingredients = ingredientService.GetAllIngredients();
            return View(ingredients);
        }
        [HttpPost]
        public IActionResult AddRecipe(IFormCollection form)
        {
            Recipe recipe = new Recipe();
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(string key in form.Keys)
            {
                string value = form[key];
                switch (key)
                {
                    case "RecipeName":
                        recipe.SetName(value);
                        break;
                    case "Description":
                        recipe.SetDesc(value);
                        break;
                    case "__RequestVerificationToken":
                        break;
                    default:
                        if (value == "true")
                        {
                            Ingredient ingredient = ingredientService.GetIngredientById(int.Parse(key));
                            ingredients.Add(ingredient);
                        }
                        break;
                }
            }
            recipe.SetIngredients(ingredients);
            return RedirectToAction("Add");
        }
    }
}
