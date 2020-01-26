using UnityEngine;
using Items;

public class EquipmentManager : MonoBehaviour
{
    public delegate void ItemEquipped(Equipment newItem, Equipment oldItem);
    public event ItemEquipped OnItemEquipped;

    private GameObject prefab;
    private GameObject itemHelp;

    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject currentHand;

    private Equippable currentItem;
    private Equipment currentEquipment;

    private Inventory inventory;
    private Hotbar hotbar;

    void Start()
    {
        leftHand = GameObject.Find("mixamorig1:LeftHand");
        rightHand = GameObject.Find("mixamorig1:RightHand");

        currentHand = rightHand;

        inventory = GetComponent<Inventory>();
        inventory.OnItemUsed += OnItemUsed;
        inventory.OnItemRemoved += OnItemRemoved;

        hotbar = FindObjectOfType<Hotbar>();
        hotbar.OnItemSelected += EquipItem;
    }

    public void UsePrimary()
    {
        if (currentItem != null && currentItem is Equippable && currentEquipment != null && currentEquipment is Weapon)
        {
            EquipmentAnimation[] animations = currentEquipment.equipmentAnimations;
            if (animations.Length != 0)
            {
                EquipmentAnimation animation = currentEquipment.equipmentAnimations[Random.Range(0, animations.Length)];
                UpdateItemPosition(animation);
                GetComponent<PlayerAnimator>().SetEquipmentAnimation(animation);
            }
            currentItem.OnPrimary();
        }
    }

    public void UseSecondary()
    {
        if (currentItem != null && currentItem is Equippable && currentEquipment != null && currentEquipment is Weapon)
        {
            currentItem.OnSecondary();
        }
    }

    public void UseConsumable()
    {
        if (currentItem != null && currentItem is Consumable && currentEquipment != null && currentEquipment is Drink)
        {
            currentItem.OnPrimary();
        }
    }


    private void OnItemUsed(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment)
        {
            Unequip();
            if (e.item.slot.Count == 0)
            {
                EquipFirstItemInHotbar();
            }
        }
    }

    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment)
        {
            Unequip();
            if (e.item.slot.Count == 0)
            {
                EquipFirstItemInHotbar();
            }
        }
    }

    public void EquipItem(Equipment item)
    {
        GameObject prefabCopy = Instantiate(item.prefab);
        GameObject itemHelpCopy = Instantiate(item.itemHelp);
        Equippable equippable = prefabCopy.GetComponent<Equippable>();
        if (equippable != null)
        {
            OnItemEquipped?.Invoke(item, currentEquipment);
            equippable.OnEquip();

            if (currentItem != null) Unequip();
            Equip(prefabCopy, itemHelpCopy, item);

            prefab = prefabCopy;
            itemHelp = itemHelpCopy;
            currentItem = equippable;
            currentEquipment = item;
        }
    }

    public void UpdateItemPosition(EquipmentAnimation animation)
    {
        UpdateItemPosition(animation.hand, animation.specificPosition, animation.specificRotation);
    }

    public void UpdateItemPosition(Hand hand, Vector3 position, Vector3 rotation)
    {
        currentHand = GetHandGameObject(hand);
        SetItemPosition(prefab, currentHand, position, rotation);
    }

    private void Equip(GameObject prefab, GameObject itemHelp, Equipment equipment)
    {
        currentHand = GetHandGameObject(equipment.defaultHand);
        SetItemPosition(prefab, currentHand, equipment.defaultPosition, equipment.defaultRotation);
        SetItemHelp(itemHelp);
    }

    private void SetItemHelp(GameObject itemHelp)
    {
        itemHelp.SetActive(true);
        //itemHelp.transform.parent = UIManager.instance.hud.gameObject.transform;
        itemHelp.transform.SetParent(UIManager.instance.hud.gameObject.transform, false);
    }

    private void SetItemPosition(GameObject prefab, GameObject hand, Vector3 position, Vector3 rotation)
    {
        prefab.SetActive(true);
        prefab.transform.parent = hand.transform;
        prefab.transform.localPosition = position;
        prefab.transform.localEulerAngles = rotation;
    }

    private void Unequip()
    {
        currentItem = null;
        currentEquipment = null;
        currentHand = null;
        Destroy(prefab);
        Destroy(itemHelp);
    }

    private GameObject GetHandGameObject(Hand hand)
    {
        if (hand == Hand.Left) return leftHand;
        else return rightHand;
    }

    private void EquipFirstItemInHotbar()
    {
        Item firstItem = inventory.slots[0].FirstItem;
        if (firstItem is Equipment)
        {
            EquipItem(firstItem as Equipment);
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
