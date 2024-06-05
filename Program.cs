using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // Set console encoding to UTF-8

        bool playAgain = true;

        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Adventure of the Mystic Woods!");
            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();
            Character player = new Character(name);

            StartGame(player);

            Console.WriteLine("Do you want to play again? (type 'yes' or 'no')");
            string replayChoice = Console.ReadLine().ToLower();
            playAgain = replayChoice == "yes";
        }
    }

    static void StartGame(Character player)
    {
        Console.WriteLine($"Hello, {player.Name}. Your adventure begins now!");
        player.ShowStats();

        bool gameRunning = true;

        while (gameRunning && player.Health > 0)
        {
            Console.WriteLine("\nYou come to a fork in the path. Do you go left towards the towering mountains (type 'left') or right into the dense forest (type 'right')?");
            string choice = Console.ReadLine().ToLower();

            if (choice == "left")
            {
                EncounterMountainPath(player);
            }
            else if (choice == "right")
            {
                EncounterForestPath(player);
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("You have succumbed to your injuries. Game over.");
                gameRunning = false;
            }
        }
    }

    static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
    }

    static string ReadAsciiArt(string fileName)
    {
        string filePath = Path.Combine("artwork", fileName);
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            return $"Error reading file: {ex.Message}";
        }
    }

    static void EncounterMountainPath(Character player)
    {
        Console.WriteLine("You chose to go left towards the towering mountains.");
        Console.WriteLine("As you climb, you slip and fall, taking 10 damage.");
        player.TakeDamage(10);
        player.ShowStats();
        Pause();

        Console.WriteLine("Do you wish to rest and regain some health? (type 'yes' or 'no')");
        string restChoice = Console.ReadLine().ToLower();
        if (restChoice == "yes")
        {
            player.Rest();
            Console.WriteLine("You take a rest and regain 20 health.");
            player.ShowStats();
            Pause();
        }

        Console.WriteLine("As you continue your climb, you encounter a huge golem. Its sheer size and presence scare you back into the forest.");
        string golemArt = ReadAsciiArt("golem.txt");
        Console.WriteLine(golemArt);
        Pause();

        player.TakeDamage(10); // Additional damage from the scare
        player.ShowStats();
        Pause();

        EncounterForestPath(player); // Redirect to forest path
    }

    static void EncounterForestPath(Character player)
    {
        Console.WriteLine("You chose to go right into the dense forest.");
        Console.WriteLine("As you walk through the forest, you step on a trap! Thorns shoot up from the ground, dealing 10 damage.");
        player.TakeDamage(10);
        player.ShowStats();
        Pause();

        Console.WriteLine("You hear a noise in the bushes. Do you choose to investigate (type 'investigate') or keep walking (type 'walk')?");
        string forestChoice = Console.ReadLine().ToLower();

        if (forestChoice == "investigate")
        {
            Enemy beast = new Enemy("Wild Beast", 30, 5);
            Console.WriteLine("A wild beast jumps out from the bushes! Prepare to fight.");
            string beastArt = ReadAsciiArt("beast.txt");
            Console.WriteLine(beastArt);
            Pause();

            CombatSystem.Fight(player, beast);

            if (player.Health > 0)
            {
                Console.WriteLine("You defeated the beast and find a healing potion.");
                Item potion = new Item("Healing Potion", 20);
                potion.Use(player);
                Console.WriteLine("You use the potion and regain 20 health.");
                player.ShowStats();
                Pause();
            }
        }
        else if (forestChoice == "walk")
        {
            Console.WriteLine("You continue walking and find a small clearing to rest.");
            Pause();
        }
        else
        {
            Console.WriteLine("Invalid choice, you get lost in the forest and take 10 damage.");
            player.TakeDamage(10);
            player.ShowStats();
            Pause();
        }

        EnterForestMaze(player);
    }

    static void EnterForestMaze(Character player)
    {
        Console.WriteLine("You have entered a dense part of the forest that seems like a maze. You need to find your way out.");
        Pause();

        bool mazeCompleted = false;
        while (!mazeCompleted && player.Health > 0)
        {
            Console.WriteLine("You see paths leading in three directions: left, right, and straight. Which way do you go? (type 'left', 'right', or 'straight')");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "left":
                    Console.WriteLine("You encounter a dead end and take 10 damage from thorny bushes.");
                    player.TakeDamage(10);
                    player.ShowStats();
                    Pause();
                    break;
                case "right":
                    Console.WriteLine("You find a healing herb and regain 20 health.");
                    player.Rest();
                    player.ShowStats();
                    Pause();
                    break;
                case "straight":
                    Console.WriteLine("You find an exit to the maze!");
                    mazeCompleted = true;
                    Pause();
                    break;
                default:
                    Console.WriteLine("Invalid choice, you wander aimlessly and take 10 damage.");
                    player.TakeDamage(10);
                    player.ShowStats();
                    Pause();
                    break;
            }
        }

        if (player.Health > 0)
        {
            EncounterBoss(player);
        }
        else
        {
            Console.WriteLine("You have succumbed to your injuries. Game over.");
        }
    }

    static void EncounterBoss(Character player)
    {
        Console.WriteLine("You find a clearing with a large chest, but it's guarded by a fearsome boss.");
        string bossArt = ReadAsciiArt("boss.txt");
        Console.WriteLine(bossArt);
        Pause();

        Enemy boss = new Enemy("Forest Guardian", 50, 10);
        CombatSystem.Fight(player, boss);

        if (player.Health > 0)
        {
            Console.WriteLine("You have defeated the Forest Guardian! You open the chest and find a map to safety.");
            Console.WriteLine("Congratulations, you have completed your adventure and found the treasure!");
            Environment.Exit(0); // Exit the game
        }
        else
        {
            Console.WriteLine("The Forest Guardian has defeated you. Game over.");
            Environment.Exit(0); // Exit the game
        }
    }
}
