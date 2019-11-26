using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    HotbarSlot[] slots;
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChanged += UpdateUI;

        slots = GetComponentsInChildren<HotbarSlot>();
        Debug.Log(slots.Length);
    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].Add(inventory.items[i]);
            } else
            {
                slots[i].Clear();
            }
        }
    }
}
