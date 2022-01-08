using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UserInterface.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

            public string UserName { get; set; }
            public int HitPoints { get; set; }
            public int AttackModifier { get; set; }
            public int AttackPerRound { get; set; }
            public int Damage { get; set; }
            public int Weapon { get; set; }
            public int AC { get; set; }
            
    }
}