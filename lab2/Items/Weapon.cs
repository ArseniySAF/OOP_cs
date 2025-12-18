namespace lab2.Items;

public class Weapon : Item
{
    public int Damage { get; private set; }

    public Weapon(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    public override void Use()
    {
        IsEquipped = true;
    }

    public void Upgrade()
    {
        Damage += 5;
    }
}
