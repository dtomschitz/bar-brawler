using UnityEngine;
using Items;

namespace Shop
{
    /// <summary>
    /// Class <c>ShopItem</c> is used to store beside a reference of the item
    /// the item price and an short info text
    /// </summary>
    [CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
    public class ShopItem : ScriptableObject
    {
        public Item item;
        public string infoText;
        public int price;

        public virtual void OnItemBought()
        {
            Player.instance.inventory.AddItem(item);
            Player.instance.RemoveMoney(price);

            Statistics.instance.AddMoney(price);
        }
    }
}