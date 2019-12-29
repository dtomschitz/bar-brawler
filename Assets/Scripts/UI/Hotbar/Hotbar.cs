using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    /*Inventory inventory;
    HotbarSlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChanged += UpdateUI;

        slots = GetComponentsInChildren<HotbarSlot>();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].Add(inventory.items[i], i == Player.instance.GetSelectedHotbarIndex());
            } else
            {
                slots[i].Clear();
            }
        }
    }*/

    private Inventory inventory;
    private List<HotbarSlot> slots;

    void Start()
    {
        inventory = Player.instance.inventory;
        inventory.ItemAdded += OnItemAdded;
        inventory.ItemRemoved += OnItemRemoved;

        slots = new List<HotbarSlot>(GetComponentsInChildren<HotbarSlot>());
        foreach (HotbarSlot slot in slots) slot.Clear();
    }

    private void OnItemAdded(object sender, InventoryEvent e) {
        for (int i = 0; i < slots.Count; i++)
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
        for (int i = 0; i < slots.Count; i++)
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
