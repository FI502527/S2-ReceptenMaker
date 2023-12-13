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
            if (TempData.ContainsKey("IngredientEdit") || TempData.ContainsKey("IngredientDelete"))
            {
                if (Convert.ToBoolean(TempData["IngredientEdit"]))
                {
                    ViewBag.Message = "Your ingredient has been edited!";
                }
                else
                {
                    ViewBag.Message = "Your ingredient has not been edited!";
                }
                if (Convert.ToBoolean(TempData["IngredientDelete"]))
                {
                    ViewBag.Message = "Your ingredient has been deleted!";
                }
                else
                {
                    ViewBag.Message = "Your ingredient has not been deleted!";
                }
            }
            List<Ingredient> allIngredients = ingredientService.GetAllIngredients();
            return View(allIngredients);
        }
        public IActionResult Add()
        {
            if (TempData.ContainsKey("IngredientAdd"))
            {
                if (Convert.ToBoolean(TempData["IngredientAdd"]))
                {
                    ViewBag.Message = "Your ingredient has been added!";
                }
                else
                {
                    ViewBag.Message = "Your ingredient has not been added!";
                }
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
                TempData["IngredientAdd"] = true;
            }
            else
            {
                TempData["IngredientAdd"] = false;
            }
            return RedirectToAction("Add");
        }
        public IActionResult Edit(int id)
        {
            Ingredient ingredient = ingredientService.GetIngredientById(id);
            return View(ingredient);
        }
        public IActionResult EditIngredient(string name, string desc)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.SetName(name);
            ingredient.SetDescription(desc);
            bool editCheck = ingredientService.EditIngredient(ingredient);
            TempData["IngredientEdit"] = editCheck;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            bool deleteCheck = ingredientService.DeleteIngredient(id);
            TempData["DeleteCheck"] = deleteCheck;
            if (deleteCheck)
            {
                TempData["IngredientDelete"] = true;
            }
            else
            {
                TempData["IngredientDelete"] = false;
            }
            return RedirectToAction("Index");
        }
    }
}
