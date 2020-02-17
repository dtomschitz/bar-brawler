using System;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    private int maxSlots = 5;

    public List<InventorySlot> slots = new List<InventorySlot>();
    public List<Item> defaultItems = new List<Item>();

    [Header("Munition")]
    public int currentMunition = 0;
    public int maxMunition = 30;

    public delegate void MunitionUpdate(int currentAmount);
    public event MunitionUpdate OnMunitionUpdate;

    public event EventHandler<InventoryEvent> OnItemAdded;
    public event EventHandler<InventoryEvent> OnItemRemoved;
    public event EventHandler<InventoryEvent> OnItemUsed;

    void Start()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot(i));
        }

        foreach(Item item in defaultItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
        if (item == null) return;
        if (item.addToInventory)
        {
            InventorySlot freeSlot = FindStackableSlot(item);

            if (freeSlot == null) freeSlot = FindNextEmptySlot();
            if (freeSlot != null)
            {
                freeSlot.Add(item);
                OnItemAdded?.Invoke(this, new InventoryEvent(item));
            }
        }
    }

    public void AddMunition(int ammount)
    {
        currentMunition += ammount;
        OnMunitionUpdate?.Invoke(currentMunition);
    }

    public void RemoveItem(Item item)
    {
        if (item == null) return;
        foreach (InventorySlot slot in slots)
        {
            if (slot.Remove(item))
            {
                OnItemRemoved?.Invoke(this, new InventoryEvent(item));
                break;
            }
        }
    }

    public void UseItem(Item item)
    {
        OnItemUsed?.Invoke(this, new InventoryEvent(item));
        RemoveItem(item);
    }

    public void UseMunition()
    {
        currentMunition--;
        OnMunitionUpdate?.Invoke(currentMunition);
    }

    public InventorySlot FindStackableSlot(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsStackable(item)) return slot;
        }
        return null;
    }

    public InventorySlot FindNextEmptySlot()
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty) return slot;
        }
        return null;
    }

    public bool HasItem(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.IsEmpty && slot.FirstItem.name == item.name) return true;
        }

        return false;
    }

    public bool IsFull
    {
        get
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.IsEmpty || !slot.IsFull) return false;
            }

            return true;
        }
    }

    public bool HasMunition
    {
        get { return currentMunition > 0; }
    }
}
