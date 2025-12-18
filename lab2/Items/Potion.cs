namespace lab2.Items;

public class Potion : Item
{
    public int HealAmount { get; }

    public Potion(string name, int healAmount) : base(name)
    {
        HealAmount = healAmount;
    }

    public override void Use() {}
}
