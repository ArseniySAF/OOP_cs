namespace lab3.Pricing;

public class BasicPriceCalculator : IPriceCalculator
{
    public decimal Calculate(decimal basePrice)
    {
        return basePrice;
    }
}
