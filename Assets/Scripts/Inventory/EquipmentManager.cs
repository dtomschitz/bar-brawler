using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public delegate void OnEquipmentChanged(EquippableItem newItem, EquippableItem oldItem);
    public event OnEquipmentChanged onEquipmentChanged;

    public GameObject playerHand;

    EquippableItem currentItem;
    Inventory inventory;

    void Start()
    {
        inventory = Player.instance.inventory;
    }

    public void Equip(EquippableItem item)
    {
        if (true)
        {
            EquippableItem oldItem = null;
            if (currentItem != null)
            {
                oldItem = currentItem;
                //inventory.AddItem(oldItem);
            }

            if (onEquipmentChanged != null) onEquipmentChanged.Invoke(item, oldItem);

            currentItem = item;
            /*if (item is Weapon)
            {
                Player.instance.animator.SetWeapon((item as Weapon).weaponType);
            }*/

            AttachToHand(item);
        }
    }

    public void Unequip()
    {
       /* if (currentItem != null)
        {
            Equippable oldItem = currentItem;
           // inventory.AddItem(oldItem);

            currentItem = null;
           // if (currentMesh != null) Destroy(currentMesh.gameObject);

            if (onEquipmentChanged != null) onEquipmentChanged.Invoke(null, oldItem);
        }*/
    }

    void AttachToHand(EquippableItem item)
    {
        item.gameObject.SetActive(true);
        item.OnUse();
        item.gameObject.transform.parent = playerHand.transform;
    }
}
