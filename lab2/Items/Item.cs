namespace lab2.Items;

public abstract class Item
{
    public string Name { get; }
    public bool IsEquipped { get; protected set; }

    protected Item(string name)
    {
        Name = name;
    }

    public abstract void Use();
}
