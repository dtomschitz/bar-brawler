using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject playerHand;
    public event EventHandler<EquipmentEvent> OnItemEquipped;

    private GameObject prefab;
    private Equippable currentItem;
    private Equipment currentEquipment;

    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        inventory.ItemUsed += OnItemUsed;
    }

    private void OnItemUsed(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment)
        {
            Unequip();
            if (e.item.slot.Count == 0)
            {
                Item firstItem = inventory.slots[0].FirstItem;
                if (firstItem is Equipment)
                {
                    EquipItem(firstItem as Equipment);
                }
            }
        }
    }

    public void EquipItem(Equipment item)
    {
        GameObject prefabCopy = Instantiate(item.prefab);
        Equippable equippable = prefabCopy.GetComponent<Equippable>();
        if (equippable != null)
        {
            OnItemEquipped?.Invoke(this, new EquipmentEvent(item, currentEquipment));
            equippable.OnEquip();

            if (currentItem != null) Unequip();
            Equip(prefabCopy, item);

            prefab = prefabCopy;
            currentItem = equippable;
            currentEquipment = item;

            if (item is Equipment)
            {
                Player.instance.animator.SetItem(item.itemType);
            }
        }

    }

    private void Equip(GameObject prefab, Equipment equipment)
    {
        prefab.SetActive(true);
        prefab.transform.parent = playerHand.transform;
        prefab.transform.localPosition = equipment.pickPosition;
        prefab.transform.localEulerAngles = equipment.pickRotation;
    }

    private void Unequip()
    {
        currentItem = null;
        currentEquipment = null;
        Destroy(prefab);
    }

    public Equippable CurrentItem
    {
        get { return currentItem; }
    }

    public Equipment CurrentEquipment
    {
        get { return currentEquipment; }
    }
}
