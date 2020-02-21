using UnityEngine;
using Items;

/// <summary>
/// Class <c>EntityEquipment</c> is used as the base class which handles the
/// current equiped item and the associated methods such as <see cref="UsePrimary"/>
/// <see cref="UseSecondary"/> and <see cref="UseConsumable"/>
/// </summary>
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

    /// <summary>
    /// This method calls the <see cref="Equippable.OnPrimary"/> method of the
    /// current selected equipment item.
    /// If the equipment is of the type weapon the method will also determinate
    /// the new random animation id in order to play different animations for
    /// each attack.
    /// </summary>
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

    /// <summary>
    /// This method calls the <see cref="Equippable.OnPrimary"/> method of the
    /// current selected equipment item if it is of the type weapon.
    /// </summary>
    public void UseSecondary()
    {
        if (currentItem != null && currentItem is Equippable && currentEquipment != null && currentEquipment is Weapon)
        {
            currentItem.OnSecondary();
        }
    }

    /// <summary>
    /// This method calls the <see cref="Consumable.OnPrimary"/> method of the
    /// current selected equipment item if it is of the type drink.
    /// </summary>
    public void UseConsumable()
    {
        if (currentItem != null && currentItem is Consumable && currentEquipment != null && currentEquipment is Drink)
        {
            currentItem.OnPrimary();
        }
    }

    /// <summary>
    /// This method equipps the given item and creates a new game object out of
    /// the items prefab. If the created game object contains the <see cref="Equippable"/>
    /// component the item will be given to the hand of the player. 
    /// </summary>
    /// <param name="item"></param>
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

    /// <summary>
    /// Sets the given game object into the hand of the default hand of the equipment item.
    /// </summary>
    /// <param name="gameObject">The game object of the equipped item.</param>
    /// <param name="item">The equipment item.</param>
    protected void Equip(GameObject gameObject, Equipment item)
    {
        currentHand = GetHandGameObject(item.defaultHand);
        SetItemPosition(gameObject, currentHand.transform, item.defaultPosition, item.defaultRotation);
    }

    /// <summary>
    /// Updates the parent, position and rotation of the created equipment prefab to the given parameters. 
    /// </summary>
    /// <param name="gameObject">The game object of the equipped item.</param>
    /// <param name="hand">The transform of the current <see cref="Hand"/></param>
    /// <param name="position">The new poisition of the given game object</param>
    /// <param name="rotation">The new rotation of the given game object</param>
    protected void SetItemPosition(GameObject gameObject, Transform hand, Vector3 position, Vector3 rotation)
    {
        //prefab.SetActive(true);
        gameObject.transform.parent = hand;
        gameObject.transform.localPosition = position;
        gameObject.transform.localEulerAngles = rotation;
    }

    /// <summary>
    /// Sets the equipped item into the hand from the given <see cref="EquipmentAnimation"/>
    /// which contains an overriden hand position.
    /// </summary>
    /// <param name="animation">The equipment animation with the new hand position.</param>
    public void UpdateItemPosition(EquipmentAnimation animation)
    {
        UpdateItemPosition(animation.hand, animation.specificPosition, animation.specificRotation);
    }

    /// <summary>
    /// Sets the equipped item into the given hand and updates the item position
    /// and rotation.
    /// </summary>
    /// <param name="hand">The new hand</param>
    /// <param name="position">The position of the item in the hand</param>
    /// <param name="rotation">The rotation of the item in the hand</param>
    public void UpdateItemPosition(Hand hand, Vector3 position, Vector3 rotation)
    {
        currentHand = GetHandGameObject(hand);
        SetItemPosition(currentItemGameObject, currentHand.transform, position, rotation);
    }

    /// <summary>
    /// Unequips the current item, resets all settings to the default and
    /// destroys the once created game object which the entity held in his hands.
    /// </summary>
    protected void Unequip()
    {
        Destroy(currentItemGameObject, 10f);

        CurrentItem.gameObject.SetActive(false);
        currentItem = null;
        currentEquipment = null;
        currentHand = null;
    }

    /// <summary>
    /// This method determinates which hand object should be used based on
    /// the given <see cref="Hand"/>.
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    private GameObject GetHandGameObject(Hand hand)
    {
        if (hand == Hand.Left) return leftHand;
        else return rightHand;
    }

    /// <summary>
    /// Returns the current equipped <see cref="Equippable"/> object.
    /// </summary>
    public Equippable CurrentItem
    {
        get { return currentItem; }
    }

    /// <summary>
    /// Returns the current equipment item.
    /// </summary>
    public Equipment CurrentEquipment
    {
        get { return currentEquipment; }
    }
}
