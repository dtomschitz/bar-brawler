using UnityEngine;
using UnityEngine.UI;


public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    private Equippable item;

    public void Add(Equippable item)
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
