using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject playerHand;

    private EquippableItem currentItem;
    private Inventory inventory;
    void Start()
    {
        inventory = GetComponent<Inventory>();
        inventory.ItemUsed += OnItemUsed;
    }

    private void OnItemUsed(object sender, InventoryEvent e)
    {
        //if (currentItem != null) AttachToHand(e.item, false);
        AttachToHand(e.item, true);
        currentItem = e.item;

        if (e.item.type == ItemType.Weapon && e.item is Weapon)
        {
            Player.instance.animator.SetWeapon((e.item as Weapon).weaponType);
        }
    }

    private void AttachToHand(EquippableItem item, bool active)
    {
        item.gameObject.SetActive(active);
        item.gameObject.transform.parent = active ? playerHand.transform : null;
    }
}
