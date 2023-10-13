using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recipe_Maker.Models;
using DAL;

namespace Recipe_Maker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestDal _testDal;

        public HomeController(ILogger<HomeController> logger, TestDal testDal)
        {
            _logger = logger;
            _testDal = testDal;
        }

        public IActionResult Index()
        {
            var userViewModels = new List<User>();
            var users = _testDal.GetAllUsers();
            foreach (var user in users)
            {
                userViewModels.Add(new User()
                {
                    Id = user.Id,
                    Username = user.Username,
                    RoleId = user.RoleId
                });
            }
            return View(userViewModels);
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