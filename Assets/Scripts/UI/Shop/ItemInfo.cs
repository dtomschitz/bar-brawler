using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Shop;

public class ItemInfo : MonoBehaviour
{
    public Text title;
    public Image image;
    public TextMeshProUGUI info;
    public Button buyButton;

    private ShopItem item;

    public void SetItem(ShopItem shopItem)
    {
        this.item = shopItem;

        gameObject.SetActive(true);

        title.text = shopItem.item.name.ToUpper();
        image.sprite = shopItem.item.icon;
        info.text = shopItem.infoText.ToUpper;
        buyButton.GetComponent<Text>().text = "BUY FOR $" + shopItem.price.ToString();
    }

    public void OnItemBought()
    {
        if (Player.instance.currentBalance >= item.price)
        {
            item.OnItemBought();
        }
    }
}
