using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<EquippableItem> defaultItems = new List<EquippableItem>();
    public int maxSlots = 5;

    public event EventHandler<InventoryEvent> ItemAdded;
    public event EventHandler<InventoryEvent> ItemRemoved;
    public event EventHandler<InventoryEvent> ItemUsed;

    void Start()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new Slot(i));
        }

        foreach(EquippableItem item in defaultItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(EquippableItem item)
    {
        if (item.addToInventory)
        {
            Slot freeSlot = FindStackableSlot(item);
            if (freeSlot == null) freeSlot = FindNextEmptySlot();

            if (freeSlot != null)
            {
                freeSlot.Add(item);
                ItemAdded?.Invoke(this, new InventoryEvent(item));

            }
        }
    }

    public void RemoveItem(EquippableItem item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.Remove(item))
            {
                ItemRemoved?.Invoke(this, new InventoryEvent(item));
                break;
            }

        }
    }

    internal void UseItem(EquippableItem item)
    {
        ItemUsed?.Invoke(this, new InventoryEvent(item));
        item.OnUse();
    }

    private Slot FindStackableSlot(EquippableItem item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsStackable(item)) return slot;
        }
        return null;
    }

    private Slot FindNextEmptySlot()
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty) return slot;
        }
        return null;
    }
}
