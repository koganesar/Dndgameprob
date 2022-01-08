using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;

namespace Ui.Controllers
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
