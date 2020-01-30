using UnityEngine;
using Items;

public class EntityEquipment : MonoBehaviour
{
    public delegate void ItemEquipped(Equipment newItem, Equipment oldItem);
    public event ItemEquipped OnItemEquipped;

    [Header("Hands")]
    public GameObject rightHand;
    public GameObject leftHand;

    protected GameObject currentItemGameObject;
    protected GameObject currentHand;

    protected Equippable currentItem;
    protected Equipment currentEquipment;

    protected virtual void Start()
    {
        currentHand = rightHand;
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
                GetComponent<EntityAnimator>().SetEquipmentAnimation(animation);
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

            currentItemGameObject = prefabCopy;
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
        SetItemPosition(currentItemGameObject, currentHand, position, rotation);
    }

    protected void Equip(GameObject prefab, Equipment item)
    {
        currentHand = GetHandGameObject(item.defaultHand);
        SetItemPosition(prefab, currentHand, item.defaultPosition, item.defaultRotation);

        if (item.itemHelp)
        {
            UIManager.instance.hud.helpInfo.UpdateHelp(item.itemHelp);
        }
    }

    protected void SetItemPosition(GameObject prefab, GameObject hand, Vector3 position, Vector3 rotation)
    {
        //prefab.SetActive(true);
        prefab.transform.parent = hand.transform;
        prefab.transform.localPosition = position;
        prefab.transform.localEulerAngles = rotation;
    }

    protected void Unequip()
    {
        Destroy(currentItemGameObject, 10f);

        CurrentItem.gameObject.SetActive(false);
        currentItem = null;
        currentEquipment = null;
        currentHand = null;
    }

    private GameObject GetHandGameObject(Hand hand)
    {
        if (hand == Hand.Left) return leftHand;
        else return rightHand;
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
