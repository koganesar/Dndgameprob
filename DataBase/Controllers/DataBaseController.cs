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
                    Name = "qwe",
                    HitPoints = 0,
                    AttackModifier = 0,
                    AttackPerRound = 0,
                    Damage = 0,
                    DiceType = 0,
                    DamageModifier = 0,
                    Weapon = 0,
                    AC = 0
                });
                appDataContext.Add(new Monster
                {
                    Name = "asd",
                    HitPoints = 0,
                    AttackModifier = 0,
                    AttackPerRound = 0,
                    Damage = 0,
                    DiceType = 0,
                    DamageModifier = 0,
                    Weapon = 0,
                    AC = 0
                });
                appDataContext.Add(new Monster
                {
                    Name = "zxc",
                    HitPoints = 0,
                    AttackModifier = 0,
                    AttackPerRound = 0,
                    Damage = 0,
                    DiceType = 0,
                    DamageModifier = 0,
                    Weapon = 0,
                    AC = 0
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
