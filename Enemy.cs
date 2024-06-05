/// <summary>
/// Enemy class
/// </summary>
class Enemy
{
    public string Name;
    public int Health;
    public int Strength;

    public Enemy(string name, int health, int strength)
    {
        Name = name;
        Health = health;
        Strength = strength;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }
}
