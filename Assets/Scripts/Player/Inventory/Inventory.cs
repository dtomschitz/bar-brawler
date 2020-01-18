using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<Item> defaultItems = new List<Item>();
    public int maxSlots = 5;

    [Header("Ammunition")]
    public int currentAmmunition = 0;
    public int maxAmmuntion = 30;


    public event EventHandler<InventoryEvent> ItemAdded;
    public event EventHandler<InventoryEvent> ItemRemoved;
    public event EventHandler<InventoryEvent> ItemUsed;

    void Start()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new Slot(i));
        }

        foreach(Item item in defaultItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
        if (item.addToInventory)
        {
            if (item is Ammunition)
            {
                AddAmmunition((item as Ammunition).amount);
                return;
            }

            Slot freeSlot = FindStackableSlot(item);
            if (freeSlot == null) freeSlot = FindNextEmptySlot();

            if (freeSlot != null)
            {
                freeSlot.Add(item);
                ItemAdded?.Invoke(this, new InventoryEvent(item));

            }
        }
    }

    public void AddAmmunition(int ammount)
    {
        currentAmmunition += ammount;
    }


    public void RemoveItem(Item item)
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

    public void UseItem(Item item)
    {
        ItemUsed?.Invoke(this, new InventoryEvent(item));
        RemoveItem(item);
    }

    public void UseAmmunition()
    {
        currentAmmunition--;
    }

    private Slot FindStackableSlot(Item item)
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

    public bool HasAmmunition
    {
        get { return currentAmmunition >= 0; }
    }
}
