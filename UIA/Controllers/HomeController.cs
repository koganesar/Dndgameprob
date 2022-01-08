using Microsoft.AspNetCore.Mvc;
using UIA.Models;

namespace UIA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => 
            View();
        
        public IActionResult Fight(Character character)
        {
            return View(character);
        }
    }
}
