using lab3.Menu;
using lab3.Status;

namespace lab3.Orders;

public abstract class Order
{
    private List<MenuItem> _items;

    public OrderStatus Status;

    public Order()
    {
        _items = new List<MenuItem>();
        Status = OrderStatus.Created;
    }

    public void AddItem(MenuItem item)
    {
        _items.Add(item);
    }

    public void NextStatus()
    {
        if (Status == OrderStatus.Created)
            Status = OrderStatus.Preparing;
        else if (Status == OrderStatus.Preparing)
            Status = OrderStatus.Delivering;
        else if (Status == OrderStatus.Delivering)
            Status = OrderStatus.Completed;
    }

    public decimal GetBasePrice()
    {
        decimal sum = 0;

        foreach (var item in _items)
        {
            sum += item.Price;
        }

        return sum;
    }

    public abstract decimal GetTotalPrice();
}
