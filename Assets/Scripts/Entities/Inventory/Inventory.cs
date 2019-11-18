using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public List<UsableItem> items = new List<UsableItem>();
    public UsableItem currentSelected;
    public int maxItems = 10;


    public bool AddItem(UsableItem item) {
        if (item.addToInventory)
        {
            if (items.Count >= maxItems) return false;

            items.Add(item);
            if (onItemChanged != null) onItemChanged.Invoke();

            return true;
        }
        return false;
    }

    public void RemoveItem(UsableItem item)
    {
        items.Remove(item);
        if (onItemChanged != null) onItemChanged.Invoke();
    }
}
