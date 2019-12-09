using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject playerHand;

    public event EventHandler<EquipmentEvent> OnItemEquipped;

    private Equippable currentItem;
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        inventory.ItemUsed += OnItemUsed;
    }

    private void OnItemUsed(object sender, InventoryEvent e)
    {
        if (currentItem != null) AttachToHand(currentItem, false);
        AttachToHand(e.item, true);

        OnItemEquipped?.Invoke(this, new EquipmentEvent(e.item, currentItem));
        currentItem = e.item;

        if (e.item.type == ItemType.Weapon && e.item is Weapon)
        {
            Player.instance.animator.SetWeapon((e.item as Weapon).weaponType);
        }
    }

    private void AttachToHand(Equippable item, bool active)
    {
        item.gameObject.SetActive(active);
        item.gameObject.transform.parent = active ? playerHand.transform : null;
    }

    public Equippable CurrentItem
    {
        get { return currentItem; }
    }
}
