using Business;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe_Maker.Controllers
{
    public class LoginController : Controller
    {
        UserService userService = new UserService();
        public IActionResult Index()
        {
            if(TempData["Error"] != null)
            {
                ViewBag.Message = TempData["Error"];
            }else if (TempData["Register"] != null)
            {
                ViewBag.Message = "Registered succesfully!";
            }
            return View();
        }
        public IActionResult LoggedIn()
        {
            string username = TempData["Username"].ToString();
            User user = userService.GetUserByName(username);
            return View(user);
        }
        public IActionResult LoginCheck(string username, string password)
        {
            bool passwordMatch = userService.LoginCheck(username, password);
            if(passwordMatch)
            {
                User user = userService.GetUserByName(username);
                TempData["Username"] = user.Username;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                TempData["Error"] = "Your username doesn't match your password!";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterUser(string username, string password)
        {
            User newUser = new User();
            newUser.CreateUser(username, 2, password);

            bool succes = userService.AddUser(newUser);
            
            if(succes)
            {
                TempData["Register"] = "Succes";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Register"] = "Fail";
                return RedirectToAction("Register");
            }
        }
    }
}
