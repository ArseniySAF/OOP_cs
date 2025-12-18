namespace lab3.Orders;

public class FastDeliveryOrder : Order
{
    public override decimal GetTotalPrice()
    {
        return GetBasePrice() + 200;
    }
}
