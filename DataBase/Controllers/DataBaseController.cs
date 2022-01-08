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
            var count = appDataContext.Monsters.Count();
            var random = new Random().Next(count);
            var monster = appDataContext.Monsters.Skip(random - 1).First();
            return new JsonResult(monster);
        }
        
    }
}