using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public Text title;
    public Text price;

    public void Add(ShopItem item)
    {
        icon.sprite = item.icon;
        icon.enabled = true;

        title.text = item.name;
        price.text = "$" + item.price;
    }
}
