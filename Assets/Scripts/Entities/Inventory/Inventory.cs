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

    public List<Item> items = new List<Item>();
    public int maxItems = 10;

    public void AddItem(Item item) {
        if (items.Count >= maxItems) return;

        items.Add(item);
        if (onItemChanged != null) onItemChanged.Invoke();
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
        if (onItemChanged != null) onItemChanged.Invoke();
    }
}
