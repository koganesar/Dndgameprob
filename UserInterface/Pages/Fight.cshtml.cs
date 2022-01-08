using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserInterface.Models;

namespace UserInterface.Pages
{
    public class Fight : PageModel
    {
        public string UserName { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public int Damage { get; set; }
        public int Weapon { get; set; }
        public int AC { get; set; }
        
        public void OnPost()
        {
            Console.WriteLine("aaaaaaaaaaaaa");
            Console.WriteLine(UserName);
        }
    }
}