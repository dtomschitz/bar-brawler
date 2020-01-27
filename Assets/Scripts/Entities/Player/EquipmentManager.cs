using UnityEngine;
using Items;

public class EquipmentManager : MonoBehaviour
{
    public delegate void ItemEquipped(Equipment newItem, Equipment oldItem);
    public event ItemEquipped OnItemEquipped;

    [Header("Hands")]
    public GameObject rightHand;
    public GameObject leftHand;

    private GameObject prefab;
    private GameObject currentHand;

    private Equippable currentItem;
    private Equipment currentEquipment;

    private Inventory inventory;
    private Hotbar hotbar;

    void Start()
    {
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

    private void OnItemUsed(Item item)
    {
        if (item == currentEquipment)
        {
            Unequip();
            if (item.slot.Count == 0)
            {
               // EquipFirstItemInHotbar();
            }
        }
    }

    private void OnItemRemoved(Item item)
    {
        if (item == currentEquipment)
        {
            Unequip();
            if (item.slot.Count == 0)
            {
               // EquipFirstItemInHotbar();
            }
        }
    }

    public void EquipItem(Equipment item)
    {
        GameObject prefabCopy = Instantiate(item.prefab);
        Equippable equippable = prefabCopy.GetComponent<Equippable>();
        if (equippable != null)
        {
            OnItemEquipped?.Invoke(item, currentEquipment);
            equippable.OnEquip();

            if (currentItem != null) Unequip();
            Equip(prefabCopy, item);

            prefab = prefabCopy;
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

    private void Equip(GameObject prefab, Equipment item)
    {
        currentHand = GetHandGameObject(item.defaultHand);
        SetItemPosition(prefab, currentHand, item.defaultPosition, item.defaultRotation);

        if (item.itemHelp)
        {
            UIManager.instance.hud.helpInfo.UpdateHelp(item.itemHelp);
        }
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
