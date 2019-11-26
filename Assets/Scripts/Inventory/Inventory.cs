using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public List<Item> items;
    public int maxItems = 5;

    private void Start()
    {
        items = new List<Item>(maxItems);
    }

    public bool AddItem(Item item) {
        if (item.addToInventory)
        {
            if (items.Count >= maxItems) return false;

            items.Add(item);
            if (onItemChanged != null) onItemChanged.Invoke();

            return true;
        }
        return false;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (onItemChanged != null) onItemChanged.Invoke();
    }
}
