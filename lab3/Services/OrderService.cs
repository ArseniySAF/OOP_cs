using lab3.Orders;

namespace lab3.Services;

public class OrderService
{
    public void ProcessOrder(Order order)
    {
        order.NextStatus();
        order.NextStatus();
        order.NextStatus();
    }
}
