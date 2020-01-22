﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;

public class Hotbar : MonoBehaviour
{
    public Text selectedItemName;

    public delegate void ItemSelected(Equipment item);
    public event ItemSelected OnItemSelected;

    private Inventory inventory;
    private HotbarSlot[] slots;

    private Coroutine currentItemNameCoroutine;
    private int selectedItemIndex = 0;

    void Start()
    {
        Player player = Player.instance;
        inventory = player.inventory;

        player.controls.OnHotbarOneForward += SelectNextItem;
        player.controls.OnHotbarOneBack += SelectLastItem;
        inventory.OnItemAdded += OnItemAdded;
        inventory.OnItemRemoved += OnItemRemoved;

        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;

        slots = GetComponentsInChildren<HotbarSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            HotbarSlot slot = slots[i];
            slot.Clear();
        }
    }

    void Update()
    {
       /* for (int i = 0; i < hotbarControls.Length; i++)
        {
            if (Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
                if (selectedHotbarIndex < inventory.slots.Count)
                {
                    SelectItem(selectedHotbarIndex);
                }
            }
        }*/
    }

    public void SelectItem(int index)
    {

    }

    public void SelectNextItem()
    {
        selectedItemIndex++;
        if (InBounds(selectedItemIndex, inventory.slots))
        {
            Item item = inventory.slots[selectedItemIndex].FirstItem;
            if (item != null && item is Equipment)
            {
                SelectItem(item as Equipment);
                return;
            }
        }
        selectedItemIndex--;
    }

    public void SelectLastItem()
    {
        selectedItemIndex--;
        if (InBounds(selectedItemIndex, inventory.slots)) {
            Item item = inventory.slots[selectedItemIndex].FirstItem;
            if (item != null && item is Equipment)
            {
                SelectItem(item as Equipment);
                return;
            }
        }
        selectedItemIndex++;
    }


    private void OnItemAdded(object sender, InventoryEvent e) 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                slots[i].Add(i, e.item);
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

    private void OnWaveStateUpdate(WaveState state, int rounds)
    {
        bool isEnabled = !WaveSpawner.instance.IsWaveRunning;

        for (int i = 0; i < slots.Length; i++)
        {
            EnableDragHandler(slots[i], isEnabled);
        }
    }

    private void SelectItem(Equipment equipment)
    {
        if (currentItemNameCoroutine != null)
        {
            StopCoroutine(currentItemNameCoroutine);
            currentItemNameCoroutine = null;
        }

        currentItemNameCoroutine = StartCoroutine(ShowSelectedName(equipment.name));
        OnItemSelected?.Invoke(equipment);
    }

    private void EnableDragHandler(HotbarSlot hotbarSlot, bool isEnabled)
    {
        hotbarSlot.IsDragAndDropEnabled = isEnabled;
    }

    private IEnumerator ShowSelectedName(string name)
    {
        selectedItemName.text = name;
        yield return new WaitForSeconds(1f);
        selectedItemName.text = "";
    }

    private bool InBounds(int index, List<Slot> slots)
    {
        return (index >= 0) && (index < slots.Count);
    }

}
