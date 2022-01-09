using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DataBase.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DataBaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomMonster([FromServices] AppDataContext appDataContext)
        {
            if (appDataContext.Monsters.Count() == 0)
            {
                appDataContext.Monsters.Add(new Monster
                {
                    Name = "Zombie",
                    HitPoints = 133,
                    AttackModifier = 3,
                    AttackPerRound = 2,
                    Damage = 4,
                    DiceType = 3,
                    DamageModifier = 2,
                    Weapon = 0,
                    AC = 5
                });
                appDataContext.Monsters.Add(new Monster
                {
                    Name = "Skeleton",
                    HitPoints = 90,
                    AttackModifier = 11,
                    AttackPerRound = 2,
                    Damage = 6,
                    DiceType = 5,
                    DamageModifier = 5,
                    Weapon = 0,
                    AC = 11
                });
                appDataContext.Monsters.Add(new Monster
                {
                    Name = "Witch",
                    HitPoints = 110,
                    AttackModifier = 11,
                    AttackPerRound = 2,
                    Damage = 3,
                    DiceType = 6,
                    DamageModifier = 6,
                    Weapon = 0,
                    AC = 12
                });
                appDataContext.SaveChanges();
            }

            return new JsonResult(appDataContext.Monsters.Skip(new Random().Next(appDataContext.Monsters.Count()))
                .First());

        }
    }
}
