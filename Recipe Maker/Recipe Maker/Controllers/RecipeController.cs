using Business;
using BusinessObjects;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Recipe_Maker.Models;

namespace Recipe_Maker.Controllers
{
    public class RecipeController : Controller
    {
        RecipeService recipeService;
        IngredientService ingredientService;
        public RecipeController(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            recipeService = new RecipeService(recipeRepository, ingredientRepository);
            ingredientService = new IngredientService(ingredientRepository);
        }
        public IActionResult Index()
        {
            List<Recipe> recipes = recipeService.GetAllRecipes();
            if (TempData.ContainsKey("NewRecipe") || TempData.ContainsKey("EditRecipe"))
            {
                if (Convert.ToBoolean(TempData["NewRecipe"]))
                {
                    ViewBag.Message = "Your recipe has been added!";
                }
                else
                {
                    ViewBag.Message = "Error no recipe has been added.";
                }
                if (Convert.ToBoolean(TempData["EditRecipe"]))
                {
                    ViewBag.Message = "Your recipe has been edited!";
                }
                else
                {
                    ViewBag.Message = "Error no recipe has been edited.";
                }
            }
            return View(recipes);
        }
        public IActionResult Add()
        {
            List<Ingredient> ingredients = ingredientService.GetAllIngredients();
            return View(ingredients);
        }
        public IActionResult Edit(int id)
        {
            Recipe recipe = recipeService.GetRecipeById(id);
            List<Ingredient> ingredients = ingredientService.GetAllIngredients();
            EditModel editModel = new EditModel(recipe, ingredients);
            return View(editModel);
        }
        [HttpPost]
        public IActionResult EditRecipe(IFormCollection form, int id)
        {
            Recipe recipe = new Recipe();
            recipe.SetId(id);
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var key in form.Keys)
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
                        Ingredient ingredient = ingredientService.GetIngredientById(int.Parse(key));
                        ingredients.Add(ingredient);
                        break;
                }
            }
            recipe.SetIngredients(ingredients);
            TempData["EditRecipe"] = recipeService.EditRecipe(recipe);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddRecipe(IFormCollection form)
        {
            Recipe recipe = new Recipe();
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(var key in form.Keys)
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
                        Ingredient ingredient = ingredientService.GetIngredientById(int.Parse(key));
                        ingredients.Add(ingredient);
                        break;
                }
            }
            recipe.SetIngredients(ingredients);
            TempData["NewRecipe"] = recipeService.AddNewRecipe(recipe);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            recipeService.DeleteRecipe(id);
            return RedirectToAction("Index");
        }
        
    }
}
