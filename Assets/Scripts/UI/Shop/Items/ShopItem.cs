using UnityEngine;
using Items;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
    public class ShopItem : ScriptableObject
    {
        public Item item;
        public string infoText;
        public int price;
        public static int spendMoney;

        public virtual void OnItemBought()
        {
            Player.instance.inventory.AddItem(item);
            Player.instance.RemoveMoney(price);
            spendMoney += price;

            FindObjectOfType<AudioManager>().Play("SelectedSound");
        }
    }
}