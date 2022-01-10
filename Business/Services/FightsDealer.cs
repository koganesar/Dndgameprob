using System.Text;
using Business.Controllers;
using Business.Models;

namespace Business.Services;

public static class FightsDealer
{

    public static string Fight(Character player, Character monster)
    {
        var stringBuilder = new StringBuilder();
        while (true)
        {
            for (var i = 0; i < player.AttackPerRound; i++)
            {
                var randomsum = 0;
                var randomAC = Random.Shared.Next(20) + 1;
                stringBuilder.Append($"Выпало: {randomAC}\n");
                for (var j = 0; j < player.Damage; j++)
                {
                    var random = Random.Shared.Next(player.DiceType) + 1;
                    randomsum += random;
                }
                
                stringBuilder.Append($"Сумма атаки составила: {randomsum}\n");

                if (monster.AC <= randomAC + player.Weapon + player.AttackModifier)
                {
                    monster.HitPoints -= randomsum + player.Weapon + player.DamageModifier;
                    stringBuilder.Append($"{player.Name} наносит урон {monster.Name}\n");
                    if (monster.HitPoints <= 0)
                    {
                        monster.HitPoints = 0;
                        stringBuilder.Append($"{player.Name} won \n");
                        return stringBuilder.ToString();
                    }
                }
            }

            for (var i = 0; i < monster.AttackPerRound; i++)
            {
                var randomsum = 0;
                var randomAC = Random.Shared.Next(20) + 1;
                stringBuilder.Append($"Выпало: {randomAC} \n");
                for (var j = 0; j < monster.Damage; j++)
                {
                    var random = Random.Shared.Next(monster.DiceType) + 1;
                    randomsum += random;
                }
                
                stringBuilder.Append($"Сумма атаки составила: {randomsum} \n");
                
                if (player.AC <= randomAC + monster.Weapon + monster.AttackModifier)
                {
                    player.HitPoints -= randomsum + monster.Weapon + monster.DamageModifier;
                    stringBuilder.Append($"{monster.Name} наносит урон {player.Name}\n");
                    if (player.HitPoints <= 0)
                    {
                        player.HitPoints = 0;
                        stringBuilder.Append($"{monster.Name} won \n");
                        return stringBuilder.ToString();
                    }
                }

            }
        }
    }
}
