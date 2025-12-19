using System;
using lab3.Menu;
using lab3.Orders;
using lab3.Status;

namespace lab3.Tests;

public static class OrderTests
{
    public static void RunAll()
    {
        Test_NewOrder_HasCreatedStatus();
        Test_AddItem_CalculatesBasePrice();
        Test_NextStatus_ChangesStatus();
        Test_StandardOrder_TotalPrice();
    }

    private static void Test_NewOrder_HasCreatedStatus()
    {
        Order order = new StandardOrder();

        if (order.Status == OrderStatus.Created)
            PrintSuccess(nameof(Test_NewOrder_HasCreatedStatus));
        else
            PrintFail(nameof(Test_NewOrder_HasCreatedStatus));
    }

    private static void Test_AddItem_CalculatesBasePrice()
    {
        Order order = new StandardOrder();
        order.AddItem(new MenuItem("Pizza", 500));
        order.AddItem(new MenuItem("Burger", 300));

        decimal price = order.GetBasePrice();

        if (price == 800)
            PrintSuccess(nameof(Test_AddItem_CalculatesBasePrice));
        else
            PrintFail(nameof(Test_AddItem_CalculatesBasePrice), price);
    }

    private static void Test_NextStatus_ChangesStatus()
    {
        Order order = new StandardOrder();

        order.NextStatus();
        order.NextStatus();

        if (order.Status == OrderStatus.Delivering)
            PrintSuccess(nameof(Test_NextStatus_ChangesStatus));
        else
            PrintFail(nameof(Test_NextStatus_ChangesStatus), order.Status);
    }

    private static void Test_StandardOrder_TotalPrice()
    {
        Order order = new StandardOrder();
        order.AddItem(new MenuItem("Test", 100));

        decimal total = order.GetTotalPrice();

        if (total == 100)
            PrintSuccess(nameof(Test_StandardOrder_TotalPrice));
        else
            PrintFail(nameof(Test_StandardOrder_TotalPrice), total);
    }


    private static void PrintSuccess(string testName)
    {
        Console.WriteLine($"{testName} passed");
    }

    private static void PrintFail(string testName, object? value = null)
    {
        Console.WriteLine($"{testName} failed. Value: {value}");
    }
}
