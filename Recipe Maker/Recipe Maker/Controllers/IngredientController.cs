using Business;
using BusinessObjects;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_Maker.Controllers
{
    public class IngredientController : Controller
    {
        IngredientService ingredientService;
        public IngredientController(IIngredientRepository ingredientRepository)
        {
            ingredientService = new IngredientService(ingredientRepository);
        }
        public IActionResult Index()
        {
            List<Ingredient> allIngredients = ingredientService.GetAllIngredients();
            return View(allIngredients);
        }
        public IActionResult Add()
        {
            if (TempData["IngredientAdd"].ToString() == "True")
            {
                ViewBag.Message = "Your ingredient has been added!";
            }
            return View();
        }
        public IActionResult AddIngredient(string name, string desc)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.SetName(name);
            ingredient.SetDescription(desc);
            bool addCheck = ingredientService.AddIngredient(ingredient);
            if (addCheck)
            {
                TempData["IngredientAdd"] = "Succes";
            }
            else
            {
                TempData["IngredientAdd"] = "Fail";
            }
            return RedirectToAction("Add");
        }
        public IActionResult Edit(int id)
        {
            if (TempData["IngredientEdit"].ToString() == "True")
            {
                ViewBag.Message = "Your ingredient has been edited!";
            }
            Ingredient ingredient = ingredientService.GetIngredientById(id);
            return View(ingredient);
        }
        public IActionResult EditIngredient(string name, string desc)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.SetName(name);
            ingredient.SetDescription(desc);
            bool editCheck = ingredientService.EditIngredient(ingredient);
            if (editCheck)
            {
                TempData["IngredientEdit"] = "Succes";
            }
            else
            {
                TempData["IngredientEdit"] = "Fail";
            }
            return RedirectToAction("Edit");
        }
    }
}
