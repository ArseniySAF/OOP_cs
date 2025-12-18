using lab2.Inventory;
using lab2.Items;
using lab2.Services;

class Program
{
    static void Main()
    {
        var inventory = new Inventory();

        var sword = new Weapon("Sword", 10);
        var armor = new Armor("Helmet", 5);
        var potion = new Potion("Health Potion", 20);
        var questItem = new QuestItem("Ancient Key");

        inventory.AddItem(sword);
        inventory.AddItem(armor);
        inventory.AddItem(potion);
        inventory.AddItem(questItem);

        inventory.UseItem("Sword");
        inventory.UseItem("Helmet");
        inventory.UseItem("Health Potion");
        inventory.UseItem("Ancient Key");

        var upgradeService = new ItemUpgradeService();
        upgradeService.TryUpgrade(sword);

        Console.WriteLine($"Sword equipped: {sword.IsEquipped}");
        Console.WriteLine($"Sword damage: {sword.Damage}");
        Console.WriteLine($"Armor equipped: {armor.IsEquipped}");
    }
}
