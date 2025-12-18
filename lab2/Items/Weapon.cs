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
        Equip();
    }

    public void Upgrade()
    {
        Damage += 5;
    }
}
