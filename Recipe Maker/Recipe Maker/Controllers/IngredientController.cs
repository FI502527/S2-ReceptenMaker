using Microsoft.AspNetCore.Mvc;

namespace Recipe_Maker.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
