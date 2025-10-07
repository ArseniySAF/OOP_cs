namespace Vendingmachine;

public class VendingMachine
{
    public List<Product> Products { get; }
    public int InsertedMoney { get; private set; }
    public int TotalMoney { get; private set; } // касса
    private int[] validCoins = { 1, 2, 5, 10 };

    public VendingMachine()
    {
        Products = new List<Product>()
        {
            new Product("Water", 30, 5),
            new Product("Tea", 40, 7),
            new Product("Bounty", 60, 10)
        };

        InsertedMoney = 0;
        TotalMoney = 0;
    }

    public void InsertCoin(int coin)
    {
        if (validCoins.Contains(coin))
        {
            InsertedMoney += coin;
            Console.WriteLine($"Вы внесли {coin} рублей\nВсего внесено: {InsertedMoney}");
        }
        else
        {
            Console.WriteLine("Вставьте только доступную монету.");
        }

    }

    public void ShowProducts()
    {
        foreach (var p in Products)
        {
            Console.WriteLine($"Имя: {p.Name} Цена: {p.Price} Кол-во: {p.Quantity}");
        }
    }

    public (bool success, string message, int change) PurchaseProduct(int index)
    {
        bool success = false;
        string message = "";
        int change = 0;

        if (index < 0 || index >= Products.Count)
        {
            message = "Неверный выбор товара.";
            return (success, message, change);
        }

        var product = Products[index];
        if (product.Quantity <= 0)
        {
            message = "Товар закончился";
            return (success, message, change);
        }

        int priceInt = (int)product.Price;
        if (InsertedMoney < priceInt)
        {
            message = $"Недостаточно денег. Цена {product.Price}, внесено {InsertedMoney}.";
            return (success, message, change);
        }

        product.Quantity--;
        TotalMoney += priceInt;

        change = InsertedMoney - priceInt;
        InsertedMoney = 0;

        success = true;
        message = $"Вы получили {product.Name}.";
        return (success, message, change);
    }

    public bool AddQProduct(int index, int amount)
    {
        if (index < 0 || index >= Products.Count || amount <= 0) return false;
        Products[index].Quantity += amount;
        return true;
    }

    public void AddProducts(string name, decimal price, int quantity)
    {
        Products.Add(new Product(name, price, quantity));
    }
}