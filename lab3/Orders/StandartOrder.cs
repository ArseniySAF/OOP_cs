namespace lab3.Orders;

public class StandardOrder : Order
{
    public override decimal GetTotalPrice()
    {
        return GetBasePrice();
    }
}
