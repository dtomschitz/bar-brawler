using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ItemSlot : MonoBehaviour
    {
        public Image icon;
        public Text title;
        public Text price;
        public Button button;

        public ShopItem shopItem;

        void Start()
        {
            icon.sprite = shopItem.item.icon;
            icon.enabled = true;

            title.text = shopItem.item.name;
            price.text = "$" + shopItem.price;
        }

        public void OnOpenItemInfo()
        {

        }
    }
}