using UnityEngine;

namespace Items
{
    public class Consumable : Equippable
    {
        private Drink drink;

        void Start()
        {
            if (!(item is Drink))
            {
                throw new UnityException("Item is not of the type Drink");
            }

            drink = (item as Drink);
        }

        public override void OnPrimary()
        {
            PlayerStats stats = Player.instance.stats;
            if (stats != null)
            {
                if (stats.HasFullLife) return;

                Player.instance.inventory.UseItem(item);
                stats.Heal(drink.healingAmount);
            }
        }
    }
}
