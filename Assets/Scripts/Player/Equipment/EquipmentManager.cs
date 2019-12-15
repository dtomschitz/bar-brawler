using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject playerHand;
    public event EventHandler<EquipmentEvent> OnItemEquipped;

    private GameObject prefab;
    private Equippable currentItem;
    private Equipment currentEquipment;

    public void EquipItem(Equipment item)
    {
        GameObject prefabCopy = Instantiate(item.prefab);
        Equippable equippable = prefabCopy.GetComponent<Equippable>();
        if (equippable != null)
        {
            Debug.Log(equippable.item.name);

            if (currentItem != null) Unequip();

            OnItemEquipped?.Invoke(this, new EquipmentEvent(item, currentEquipment));
            equippable.OnEquip();
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
        Destroy(prefab);
    }

    public Equippable CurrentItem
    {
        get { return currentItem; }
    }
}
