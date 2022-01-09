using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers;

[ApiController]
[Route("[action]")]
public class FightsController : ControllerBase
{
    public record FightStartingModel(CalculatedCharacter Player, CalculatedCharacter Monster);

    [HttpPost]
    public IActionResult StartFight(FightStartingModel model) => 
        Ok(FightsDealer.CreateFight(model));

    [HttpPost]
    public IActionResult MakeTurn([FromQuery]Guid fightId) =>
        new JsonResult(FightsDealer.MakeTurn(fightId));
}
