using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    public bool selected;
    Item item;

    public void Add(Item item, bool selected)
    {
        this.item = item;
        this.selected = selected;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null) item.Use();
    }

    public bool isEmpty()
    {
        return item != null;
    }

    public Item GetItem()
    {
        return item;
    }
}
