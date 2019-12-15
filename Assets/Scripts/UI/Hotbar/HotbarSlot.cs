using UnityEngine;
using UnityEngine.UI;


public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    private Item item;

    public void Add(Item item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
