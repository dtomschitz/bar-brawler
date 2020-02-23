using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utils;

namespace Shop
{
    /// <summary>
    /// Class <c>ItemInfo</c> is used to display some informations about the
    /// item on the right side of the shop ui.
    /// </summary>
    public class ItemInfo : MonoBehaviour
    {
        public Text title;
        public Text price;
        public Image image;
        public TextMeshProUGUI info;

        /// <summary>
        /// Updates the information based of the given item.
        /// </summary>
        /// <param name="shopItem"></param>
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
