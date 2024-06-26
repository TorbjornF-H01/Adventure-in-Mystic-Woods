Project: The Adventure of the Mystic Woods
Due Apr 5
## Objective:

Create a text-based game where the player navigates through the Mystic Woods. The player will make choices that lead them through different scenarios, ultimately guiding them to find the hidden treasure or face various endings based on their choices.

## Game Requirements:

The game should start by printing an introduction to the story. Explain that the player is at the entrance of the Mystic Woods in search of a legendary treasure. You can use LLM's such as ChatGPT to generate stories, for example: https://chat.openai.com/share/b905c06b-0914-4f2b-b1de-f37d151143a1

## Character Class:

The players Character should be defined as a class with at least two properties: Name (string) and Health (int).
Optionally, you can include other properties such as "Strength", and include methods that affect the character's state, such as TakeDamage(int damage) or Rest().

## Path Choices:

The game should present the player with choices, such as "Press 1 to go left into the dark forest" or "Press 2 to go right towards the river". Use conditionals to handle these choices.
Each path should have different outcomes, which can include finding items, encountering traps (which could decrease the player's health), or discovering clues about the treasure.

# Loops for Repeated Decisions:

In some cases implement loops to allow the player to make decisions repeatedly within certain sections of the game, for example, choosing different paths until they find a way out of a maze.

# End Game Scenarios:

The game should have multiple endings based on the decisions made by the player. This could include finding the treasure, getting lost in the woods, or running out of health due to traps.

# Basic User Input:

Use Console.ReadLine() to get input from the player (e.g., their name, decisions at paths).
Use Console.WriteLine() to print the story, choices, and outcomes to the console.

Sample code:

Character.cs:
```cs
    class Character
    {
        public string Name;
        public int Health;

    public Character(string name)
    {
        Name = name;
        Health = 100; // Default health
    }

       public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void Rest()
    {
        Health += 20;
        if (Health > 100) Health = 100;
    }
}
Program.cs:
```cs
Console.WriteLine("Welcome to the Adventure of the Mystic Woods!");
// Initialize character and start the game
Console.Write("Enter your character's name: ");
string name = Console.ReadLine();
Character player = new Character(name);

// Start game logic here
// Example: ChoosePath(player);
```


## Challenges for Extra Practice:

Add an enemy class, the enemies could then spawn randomly as the player explores.
Add an inventory system to the Character class for items found during the adventure.
Maybe implement more complex scenarios that require specific items to progress.

## Example of some gameflow ideas:

### Starting the Adventure
- The game begins with an introduction to the story, setting the scene for the player's quest in the Mystic Woods. The player is asked to enter their character's name, initializing their journey.
- Example: "As you stand at the edge of the Mystic Woods, rumors of an ancient treasure fill your mind. What is your name, brave adventurer?"

### Making Choices
- At key points in the game, the player is presented with choices that dictate the direction of their adventure. These choices can lead to different paths, encounters, or discoveries.

- Example Choice:
"You come to a fork in the path. Do you go left towards the towering mountains (type 'left') or right into the dense forest (type 'right')?"

### Encounters and Outcomes
- Based on the player's choices, they can encounter various scenarios such as finding items, facing traps, or encountering creatures.
- Finding Items: "You find a small pouch hidden under a loose stone. Inside, there's a healing potion. You add it to your inventory."
- Traps: "As you walk through the forest, you step on a trap! Thorns shoot up from the ground, dealing 10 damage."
- Creature Encounter: "A wild beast jumps out from the bushes! You must decide to fight (type 'fight') or flee (type 'flee')."

### Health and Inventory Management
- The player's health is a critical component. Encounters with traps or creatures can decrease health, and certain items can restore it. Managing health becomes a part of the strategy.
- The inventory system allows the player to collect items that can be crucial for overcoming obstacles or healing. For example, a "magic key" found early on might open a locked gate later.

### Branching Paths and Endings
- The game's structure can branch out based on the choices made, leading to multiple endings. Some paths may lead to the treasure, others to being lost forever, or even encountering a boss that guards the treasure.
- Example Ending (Treasure Found): "Following the ancient map you found, you discover the hidden entrance to a cave. Inside, the treasure of the Mystic Woods shines in the dim light. Victory is yours!"
- Example Ending (Lost): "After wandering for hours, you realize you've been walking in circles. The woods seem to have no end, and your supplies are running low."

### Combat System (Optional)
- For a more complex gameplay, a simple combat system could be introduced where the player can choose to "attack" or "defend" against creatures, with outcomes based on simple logic (e.g., attack success rate, creature health).

### Task delivery instructions
You can send a link to a github repository that coinains your code, or you can upload a zip file to google class room.