using System;
using System.Collections.Generic;
using UnityEngine;
using Items;

/// <summary>
/// Class <c>Inventory</c> is used to store all the items the player received or
/// rather buyed in the store. The inventory is split up in 5 slots which contains
/// the items. Each slot can hold the set amount of items the specific item declared.
/// With the method <see cref="AddItem(Items.Item)"/> a new item can be added to
/// the inventory and removed with the method <see cref="RemoveItem(Items.Item)"/>.
/// The inventory also keeps track of the current amount of ammunition the player has. 
/// </summary>
public class Inventory : MonoBehaviour
{
    private readonly int maxSlots = 5;

    public List<InventorySlot> Slots { get; protected set; } = new List<InventorySlot>();

    [Header("Munition")]
    public int currentMunition = 0;
    public int maxMunition = 30;

    public delegate void MunitionUpdate(int currentAmount);
    public event MunitionUpdate OnMunitionUpdate;

    public delegate void InventoryUpdate(Item item);


    public event InventoryUpdate OnItemAdded;
    public event InventoryUpdate OnItemRemoved;
    public event InventoryUpdate OnItemUsed;

    void Start()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            Slots.Add(new InventorySlot(i));
        }
    }

    /// <summary>
    /// This method adds a new item to the inventory if it is declared as a
    /// inventory item. If this is the case, a slot with the same item or a free
    /// one is searched for. If a slot is found the given item is added to it and
    /// the event <see cref="OnItemAdded"/> gets fired.
    /// </summary>
    /// <param name="item">The item which should be added to the inventory.</param>
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
                OnItemAdded?.Invoke(item);
            }
        }
    }

    /// <summary>
    /// This method removes the given item from the inventory if it could be
    /// found in on of the slots and will the fire the <see cref="OnItemRemoved"/>
    /// event.
    /// </summary>
    /// <param name="item">The item which should be removed from the inventory.</param>
    public void RemoveItem(Item item)
    {
        if (item == null) return;
        foreach (InventorySlot slot in Slots)
        {
            if (slot.Remove(item))
            {
                OnItemRemoved?.Invoke(item);
                break;
            }
        }
    }

    /// <summary>
    /// This method removes a 
    /// </summary>
    /// <param name="item"></param>
    public void UseItem(Item item)
    {
        OnItemUsed?.Invoke(item);
        RemoveItem(item);
    }

    /// <summary>
    /// Adds the given ammount of munition to the inventory and fires the
    /// <see cref="OnMunitionUpdate"/> event.
    /// </summary>
    /// <param name="ammount">The ammount of munition the player received0</param>
    public void AddMunition(int ammount)
    {
        currentMunition += ammount;
        OnMunitionUpdate?.Invoke(currentMunition);
    }

    /// <summary>
    /// This method reduces the current ammount of ammunition and fires the
    /// <see cref="OnMunitionUpdate"/> event.
    /// </summary>
    public void UseMunition()
    {
        currentMunition--;
        OnMunitionUpdate?.Invoke(currentMunition);
    }

    /// <summary>
    /// This method finds a slot which contains the type of given item and has still enough space for it.
    /// </summary>
    /// <param name="item">The item which should be added to the inventory.</param>
    /// <returns>The slot for the item.</returns>
    public InventorySlot FindStackableSlot(Item item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.IsStackable(item)) return slot;
        }
        return null;
    }

    /// <summary>
    /// This method finds a free slot in the inventory.
    /// </summary>
    /// <returns>The free slot</returns>
    public InventorySlot FindNextEmptySlot()
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.IsEmpty) return slot;
        }
        return null;
    }

    /// <summary>
    /// This method determines whether the inventory contains the given item or not.
    /// </summary>
    /// <param name="item">The item which should be checked.</param>
    /// <returns>True if the inventory contains the given item; otherwise false.</returns>
    public bool HasItem(Item item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (!slot.IsEmpty && slot.FirstItem.name == item.name) return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether all the slots of the inventory are full or not. The
    /// method will return true if this is the case; otherwise false.
    /// </summary>
    public bool IsFull
    {
        get
        {
            foreach (InventorySlot slot in Slots)
            {
                if (slot.IsEmpty || !slot.IsFull) return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Determines whether the inventory contains ammunition or not. The method
    /// will return true if this is the case; otherwise false.
    /// </summary>
    public bool HasMunition
    {
        get { return currentMunition > 0; }
    }
}
