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

    public void EquipItem(Equipment item)
    {
        GameObject prefabCopy = Instantiate(item.prefab);
        Equippable equippable = prefabCopy.GetComponent<Equippable>();
        if (equippable != null)
        {
            Debug.Log(equippable.item.name);

            OnItemEquipped?.Invoke(this, new EquipmentEvent(item, currentEquipment));
            equippable.OnEquip();

            if (currentItem != null) Unequip();
            Equip(prefabCopy, item);

            prefab = prefabCopy;
            currentItem = equippable;
            currentEquipment = item;

            if (item.type == ItemType.Weapon && item is Weapon)
            {
                Player.instance.animator.SetWeapon((item as Weapon).weaponType);
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

    private void OnItemUsed(object sender, InventoryEvent e)
    {
        Debug.Log(e.item == currentEquipment);
        if (e.item == currentEquipment)
        {
            Unequip();
            Item firstItem = inventory.slots[0].FirstItem;
            if (firstItem is Equipment)
            {
                EquipItem(firstItem as Equipment);
            }
        }
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
