using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recipe_Maker.Models;
using Business;
using BusinessObjects;
using Interfaces;

namespace Recipe_Maker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserService _userService;
        public HomeController(IUserRepository userRepository)
        {
            _userService = new UserService(userRepository);
        }

        public IActionResult Index()
        {
            List<BusinessObjects.User> users = _userService.GetAllUsers();
            return View(users);
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