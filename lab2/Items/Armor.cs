namespace lab2.Items;

public class Armor : Item
{
    public int Defense { get; private set; }

    public Armor(string name, int defense) : base(name)
    {
        Defense = defense;
    }

    public override void Use()
    {
        Equip();
    }

    public void Upgrade()
    {
        Defense += 5;
    }
}
