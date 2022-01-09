using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UIA.Models;

namespace UIA.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        public HomeController()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
            _client = new HttpClient(clientHandler);
        }


        public IActionResult Index() =>
            View();

        private record FightStartingModel(CalculatedCharacter Player, CalculatedCharacter Monster);

        [HttpPost]
        public async Task<IActionResult> Fight(Character player)
        {
            var t = (await _client.GetAsync("https://localhost:5001/GetRandomMonster")).Content;
            var monster = await t.ReadFromJsonAsync<Character>();
            t = (await _client.PostAsync("https://localhost:7299/CalculateCharacter", JsonContent.Create(monster)))
                .Content;
            var calculatedMonster = await t.ReadFromJsonAsync<CalculatedCharacter>();
            t = (await _client.PostAsync("https://localhost:7299/CalculateCharacter", JsonContent.Create(player)))
                .Content;
            var calculatedPlayer = await t.ReadFromJsonAsync<CalculatedCharacter>();
            t = (await _client.PostAsync("https://localhost:7299/StartFight",
                JsonContent.Create(new FightStartingModel(calculatedPlayer, calculatedMonster)))).Content;
            var id = Guid.Parse((await t.ReadAsStringAsync())[1..^1]);
            return View(new Fight
            {
                FightId = id,
                Player = calculatedPlayer,
                Monster = calculatedMonster,
                PlayerWon = null
            });
        }

        [HttpGet]
        public async Task<IActionResult> Fight([FromQuery] Guid fightId)
        {
            var t = (await _client.PostAsync($"https://localhost:7299/MakeTurn?fightId={fightId}", null!))
                .Content;
            return View(await t.ReadFromJsonAsync<Fight>());
        }
    }
}
