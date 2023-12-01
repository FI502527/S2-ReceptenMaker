using Business;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe_Maker.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if(TempData["Error"] != null)
            {
                ViewBag.Message = TempData["Error"];
            }
            return View();
        }
        public IActionResult LoggedIn()
        {
            UserService userService = new UserService();
            string username = TempData["Username"].ToString();
            UserObject user = userService.GetUserByName(username);
            return View(user);
        }
        public IActionResult LoginCheck(string username, string password)
        {
            UserService userService = new UserService();
            bool check = userService.LoginCheck(username, password);
            if(check)
            {
                UserObject user = userService.GetUserByName(username);
                TempData["Username"] = user.Username;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                TempData["Error"] = "Your username doesn't match your password!";
                return RedirectToAction("Index");
            }
        }
    }
}
