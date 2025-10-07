namespace Vendingmachine;

class Program
{
    static void Main()
    {
        VendingMachine vm = new VendingMachine();

        while (true)
        {
            Console.WriteLine("\n---Вендинговый Автомат---");
            Console.WriteLine("1. Show Products");
            Console.WriteLine("2. Insert Coin");
            Console.WriteLine("3. Buy Product");
            Console.WriteLine("4. Admin Mode");
            Console.WriteLine("5. Exit");
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    vm.ShowProducts();
                    break;

                case "2":
                    Console.WriteLine("Выберете номинал вставляемой монеты (1, 2, 5, 10): ");
                    string? value = Console.ReadLine();
                    try
                    {
                        int coin = Convert.ToInt32(value);
                        vm.InsertCoin(coin);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Вставьте только доступную монету.");
                    }
                    break;

                case "3":
                    vm.ShowProducts();
                    Console.Write("Введите номер товара для покупки: ");
                    try
                    {
                        int idx = Convert.ToInt32(Console.ReadLine());
                        int num = idx - 1;

                        var result = vm.PurchaseProduct(num);
                        if (!result.success)
                        {
                            Console.WriteLine(result.message);
                        }
                        else
                        {
                            Console.WriteLine(result.message);
                            if (result.change > 0)
                            {
                                Console.WriteLine($"Ваша сдача: {result.change} руб.");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Такого товара не существует.");
                    }
                    break;

                case "4":
                    Console.Write("Введите админ-пароль: ");
                    string? pass = Console.ReadLine();
                    if (pass == "admin")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n---Admin Menu---");
                            Console.WriteLine("1. Add Q to products");
                            Console.WriteLine("2. Add new product");
                            Console.WriteLine("3. Back");
                            Console.Write("Выберите действие: ");
                            string? a = Console.ReadLine();

                            switch (a)
                            {
                                case "1":
                                    vm.ShowProducts();
                                    Console.Write("Номер товара для пополнения: ");
                                    try
                                    {
                                        int num = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Количество: ");
                                        int amount = Convert.ToInt32(Console.ReadLine());

                                        if (vm.AddQProduct(num - 1, amount))
                                            Console.WriteLine("Пополнение успешно.");
                                        else
                                            Console.WriteLine("Ошибка при пополнении.");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Некорректный ввод.");
                                    }
                                    break;

                                case "2":
                                    Console.Write("Название: ");
                                    string? name = Console.ReadLine();
                                    Console.Write("Цена: ");
                                    try
                                    {
                                        int price = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Количество: ");
                                        int quant = Convert.ToInt32(Console.ReadLine());

                                        if (!string.IsNullOrEmpty(name))
                                        {
                                            vm.AddProducts(name, price, quant);
                                            Console.WriteLine("Товар добавлен.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверное название.");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Некорректный ввод.");
                                    }
                                    break;

                                case "3":
                                    Console.WriteLine("Выход из админ-меню...");
                                    goto EndAdmin;
                                    
                                default:
                                    Console.WriteLine("Неверный выбор.");
                                    break;
                            }
                        }
                        EndAdmin: ;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Выход из программы...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
