namespace lab2.Items;

public abstract class Item
{
    public string Name { get; }
    public bool IsEquipped { get; private set; }

    protected Item(string name)
    {
        Name = name;
    }

    public abstract void Use();

    protected void Equip()
    {
        IsEquipped = true;
    }

    protected void Unequip()
    {
        IsEquipped = false;
    }
}
