﻿using System;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public delegate void ItemSelected(Equipment item);
    public event ItemSelected OnItemSelected;

    private Inventory inventory;
    private HotbarSlot[] slots;

    private int selectedHotbarIndex = 0;
    private readonly KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
    };

    void Start()
    {
        inventory = Player.instance.inventory;
        inventory.ItemAdded += OnItemAdded;
        inventory.ItemRemoved += OnItemRemoved;

        slots = GetComponentsInChildren<HotbarSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            HotbarSlot slot = slots[i];
            slot.Clear();
            slot.SlotNumber = i + 1;
        }
    }

    void Update()
    {
        for (int i = 0; i < hotbarControls.Length; i++)
        {
            if (Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
                if (selectedHotbarIndex < inventory.slots.Count)
                {
                    Item item = inventory.slots[i].FirstItem;
                    if (item != null && item is Equipment)
                    {
                        OnItemSelected?.Invoke(item as Equipment);
                    }
                }
            }
        }
    }

    private void OnItemAdded(object sender, InventoryEvent e) 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                slots[i].Add(e.item);
                break;
            }
        }
    }

    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                int itemCount = e.item.slot.Count;
                if (itemCount == 0)
                {
                    slots[i].Clear();
                }
                break;
            }
        }
    }
}
