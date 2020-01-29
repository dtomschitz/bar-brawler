using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Munition")]
    public class Munition : ShopItem
    {
        public override void OnItemBought()
        {
            base.OnItemBought();
            Player.instance.inventory.AddMunition((item as Items.Munition).amount);
        }
    }
}