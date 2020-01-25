using UnityEngine;
using UnityEngine.UI;
using Shop;

public class ItemInfo : MonoBehaviour
{
    public Text title;
    public Image image;
    public Button buyButton;

    private ShopItem item;

    public void SetItem(ShopItem item)
    {
        this.item = item;

        gameObject.SetActive(true);

        title.text = item.item.name;
        image.sprite = item.item.icon;
        buyButton.GetComponent<Text>().text = "BUY FOR $" + item.price.ToString();
    }

    public void OnItemBought()
    {
        if (Player.instance.currentBalance >= item.price)
        {
            item.OnItemBought();
        }
    }
}
