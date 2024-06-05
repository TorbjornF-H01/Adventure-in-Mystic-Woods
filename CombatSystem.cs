/// <summary>
/// Combat system class
/// </summary>
class CombatSystem
{
    public static void Fight(Character player, Enemy enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            ExecuteEnemyAttack(player, enemy);
            if (CheckIfDefeated(player, enemy)) break;
            PromptForNextMove();

            ExecutePlayerAttack(player, enemy);
            if (CheckIfDefeated(player, enemy)) break;
            PromptForNextMove();
        }

        if (enemy.Health <= 0)
        {
            Gear loot = Gear.GenerateRandomGear();
            Console.WriteLine($"The {enemy.Name} has dropped {loot.Name} (Health: {loot.HealthBoost}, Strength: {loot.StrengthBoost})!");
            Console.WriteLine("Do you want to equip it? (type 'yes' or 'no')");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                loot.Equip(player);
                Console.WriteLine($"{player.Name} equipped {loot.Name}. Health: {player.Health}, Strength: {player.Strength}");
            }
        }
    }

    private static void ExecutePlayerAttack(Character player, Enemy enemy)
    {
        Console.WriteLine($"{player.Name} attacks!");
        enemy.TakeDamage(player.Strength);
        Console.WriteLine($"{enemy.Name} takes {player.Strength} damage. Health: {enemy.Health}");
    }

    private static void ExecuteEnemyAttack(Character player, Enemy enemy)
    {
        Console.WriteLine($"{enemy.Name} attacks!");
        player.TakeDamage(enemy.Strength);
        Console.WriteLine($"{player.Name} takes {enemy.Strength} damage. Health: {player.Health}");
    }

    private static bool CheckIfDefeated(Character player, Enemy enemy)
    {
        if (player.Health <= 0)
        {
            Console.WriteLine($"{player.Name} has been defeated!");
            return true;
        }

        if (enemy.Health <= 0)
        {
            Console.WriteLine($"{enemy.Name} has been defeated!");
            return true;
        }

        return false;
    }

    private static void PromptForNextMove()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
    }
}
