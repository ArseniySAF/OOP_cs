using lab2.Items;

namespace lab2.Services;

public class ItemUpgradeService
{
    public bool TryUpgrade(Item item)
    {
        if (item is Weapon weapon)
        {
            weapon.Upgrade();
            return true;
        }
        else if (item is Armor armor)
        {
            armor.Upgrade();
            return true;
        }

        return false;
    }
}
