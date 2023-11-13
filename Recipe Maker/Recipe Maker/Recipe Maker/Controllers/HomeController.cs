using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recipe_Maker.Models;
using DAL;
using BusinessObjects;

namespace Recipe_Maker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository _testDal;

        public HomeController(ILogger<HomeController> logger, UserRepository testDal)
        {
            _logger = logger;
            _testDal = testDal;
        }

        public IActionResult Index()
        {
            UserObject user = _testDal.LoadAllUsers();
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}