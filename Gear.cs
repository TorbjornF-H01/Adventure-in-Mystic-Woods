/// <summary>
/// Gear class
/// </summary>
class Gear
{
    public string Name;
    public int HealthBoost;
    public int StrengthBoost;

    public Gear(string name, int healthBoost, int strengthBoost)
    {
        Name = name;
        HealthBoost = healthBoost;
        StrengthBoost = strengthBoost;
    }

    public void Equip(Character character)
    {
        character.Health += HealthBoost;
        character.Strength += StrengthBoost;
    }

    public void Unequip(Character character)
    {
        character.Health -= HealthBoost;
        character.Strength -= StrengthBoost;
    }

    public static Gear GenerateRandomGear()
    {
        Random random = new Random();
        string[] gearNames = { "Sword", "Shield", "Armor", "Amulet" };
        string name = gearNames[random.Next(gearNames.Length)];
        int healthBoost = random.Next(5, 21); // Random health boost between 5 and 20
        int strengthBoost = random.Next(1, 11); // Random strength boost between 1 and 10

        return new Gear(name, healthBoost, strengthBoost);
    }
}

