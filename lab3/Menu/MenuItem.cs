namespace lab3.Menu;

public class MenuItem
{
    public string Name { get; }
    public decimal Price { get; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// пример: order.AddItem(new MenuItem("Pizza", 500))