/// <summary>
/// Item class
/// </summary>
class Item
{
    public string Name;
    public int HealthRestoration;

    public Item(string name, int healthRestoration)
    {
        Name = name;
        HealthRestoration = healthRestoration;
    }

    public void Use(Character character)
    {
        character.Health += HealthRestoration;
        if (character.Health > 100) character.Health = 100;
    }
}
