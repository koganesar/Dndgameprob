using Microsoft.AspNetCore.Mvc.RazorPages;
using UserInterface.Models;

namespace UserInterface.Pages
{
    public class Fight : PageModel
    {
        public Character Character { get; set; } 
        
        public void OnGet(Character myGamer)
        {
            Character = myGamer;
        }
    }
}