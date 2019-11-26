using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    Inventory inventory;
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
    }
}
