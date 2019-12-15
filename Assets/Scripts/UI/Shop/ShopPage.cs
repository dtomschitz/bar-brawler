using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPage : MonoBehaviour
{
    public int id;
    public ItemSlot itemSlotPrefab;

    public void AddItems(List<ShopItem> items)
    {
        foreach(ShopItem item in items)
        {
            ItemSlot slot = Instantiate(itemSlotPrefab, transform) as ItemSlot;
            slot.Add(item);
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
