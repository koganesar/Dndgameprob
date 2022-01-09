using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataBase.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DataBaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomMonster([FromServices] AppDataContext appDataContext)
        {
            if (appDataContext.Monsters.Count() is 0)
            {
                appDataContext.Add(new Monster
                {
                    Name = "Лемур",
                    HitPoints = 13,
                    AttackModifier = 3,
                    AttackPerRound = 1,
                    Damage = 1,
                    DiceType = 4,
                    DamageModifier = 0,
                    Weapon = 0,
                    AC = 7
                });
                appDataContext.Add(new Monster
                {
                    Name = "Мамонт",
                    HitPoints = 126,
                    AttackModifier = 10,
                    AttackPerRound = 1,
                    Damage = 4,
                    DiceType = 8,
                    DamageModifier = 7,
                    Weapon = 0,
                    AC = 13
                });
                appDataContext.Add(new Monster
                {
                    Name = "Аболет",
                    HitPoints = 135,
                    AttackModifier = 9,
                    AttackPerRound = 3,
                    Damage = 2,
                    DiceType = 6,
                    DamageModifier = 5,
                    Weapon = 0,
                    AC = 17
                });
                appDataContext.SaveChanges();
            }

            var count = appDataContext.Monsters.Count();
            var random = new Random().Next(count);
            var monster = (random > 0 ? appDataContext.Monsters.Skip(random) : appDataContext.Monsters).First();
            return new JsonResult(monster);
        }
    }
}
