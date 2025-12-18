using lab2.Items;

namespace lab2.Inventory;

public class Inventory
{
    private List<Item> _items;

    public Inventory()
    {
        _items = new List<Item>();
    }

    public List<Item> GetItems()
    {
        return _items;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public Item? FindItem(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public bool UseItem(string name)
    {
        Item? item = FindItem(name);

        if (item == null)
        {
            return false;
        }

        item.Use();
        return true;
    }
}
