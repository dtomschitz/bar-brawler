using UnityEngine;
using Items;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
    public class ShopItem : ScriptableObject
    {
        public Item item;
        public int price;

        public virtual void OnItemBought()
        {
            Player.instance.inventory.AddItem(item);
            Player.instance.RemoveMoney(price);
        }
    }

}