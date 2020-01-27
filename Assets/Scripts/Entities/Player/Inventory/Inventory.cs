using System;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    private int maxSlots = 4;

    public List<Slot> slots = new List<Slot>();
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
            slots.Add(new Slot(i));
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
            Slot freeSlot = FindStackableSlot(item);
            if (freeSlot == null) freeSlot = FindNextEmptySlot();

            Debug.Log(slots.Count);

            if (freeSlot != null)
            {
                freeSlot.Add(item);
                Debug.Log("item added: " + item.name);
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

        Debug.Log("Remove item from inv: " + item.name + "(" + item.slot.Id + ")");

        foreach (Slot slot in slots)
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

    public bool HasMunition
    {
        get { return currentMunition > 0; }
    }
}
