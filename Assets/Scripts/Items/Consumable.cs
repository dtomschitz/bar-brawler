using UnityEngine;

namespace Items
{
    public class Consumable : Equippable
    {
        private Drink drink;
        private PlayerAnimator animator;


        void Start()
        {
            if (!(item is Drink))
            {
                throw new UnityException("Item is not of the type Drink");
            }

            drink = (item as Drink);
            animator = Player.instance.animator;
        }

        public override void OnPrimary()
        {
            PlayerStats stats = Player.instance.stats;
            if (stats != null || stats.HasFullLife) return;

            Player.instance.inventory.UseItem(item);
        }
    }
}
