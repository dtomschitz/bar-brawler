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
            if (currentItem != null) AttachToHand(prefab, false);

            prefab = prefabCopy;

            equippable.OnEquip();
            AttachToHand(prefab, true);
            OnItemEquipped?.Invoke(this, new EquipmentEvent(item, currentEquipment));

            currentItem = equippable;
            currentEquipment = item;

            if (item.type == ItemType.Weapon && item is Weapon)
            {
                Player.instance.animator.SetWeapon((item as Weapon).weaponType);
            }
        }

    }

    private void AttachToHand(GameObject prefab, bool active)
    {
        prefab.SetActive(active);
        prefab.transform.parent = active ? playerHand.transform : null;
        if (!active) Destroy(prefab);
    }

    public Equippable CurrentItem
    {
        get { return currentItem; }
    }
}
