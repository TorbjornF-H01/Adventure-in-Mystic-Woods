/// <summary>
/// Character class, 
/// </summary>


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
