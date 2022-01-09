using Business.Controllers;
using Business.Models;

namespace Business.Services;

public static class FightsDealer
{
    private static readonly Dictionary<Guid, Fight> fights = new();

    private static bool Attack (CalculatedCharacter attacker, CalculatedCharacter defender)
    {
        for (var i = 0; i < attacker.AttackPerRound; i++)
        {
            defender.HitPoints -= Random.Shared.Next(attacker.DiceType) + 1 + attacker.Weapon + attacker.DamageModifier;
            if (defender.HitPoints <= 0)
                return true;
        }
        return false;
    }

    public static Fight MakeTurn(Guid fightId)
    {
        if (!fights.ContainsKey(fightId)) throw new NullReferenceException();
        var fight = fights[fightId];
        var player = fight.Player;
        var monster = fight.Monster;

        if (Attack(player, monster))
        {
            fight.PlayerWon = true;
            return fight;
        }

        if (Attack(monster, player))
            fight.PlayerWon = false;

        return fight;
    }

    public static Guid CreateFight(FightsController.FightStartingModel model)
    {
        var guid = Guid.NewGuid();
        var player = model.Player;
        var monster = model.Monster;

        var fight = new Fight
        {
            FightId = guid,
            Player = player,
            Monster = monster,
            PlayerWon = null
        };

        fights.Add(guid, fight);
        return guid;
    }
}
