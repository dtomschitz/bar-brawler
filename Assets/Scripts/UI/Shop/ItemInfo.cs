using UnityEngine.UI;
using TMPro;
using Utils;

namespace Shop
{
    public class ItemInfo : FadeGraphic
    {
        public Text title;
        public Text price;
        public Image image;
        public TextMeshProUGUI info;

        public void SetItem(ShopItem shopItem)
        {
            gameObject.SetActive(true);

            title.text = shopItem.item.name.ToUpper();
            price.text = "$" + shopItem.price.ToString();
            info.text = shopItem.infoText.ToUpper();

            image.sprite = shopItem.item.icon;
        }
    }
}
