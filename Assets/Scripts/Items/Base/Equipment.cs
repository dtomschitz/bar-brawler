using UnityEngine;

namespace Items
{

    /// <summary> 
    /// Class <c>Equipment</c> extends the Item class and is used to give items
    /// the option to get equipped by the <see cref="EntityEquipment"/> class. In
    /// order to use equip this item correctly, the class has to store the default
    /// position, rotation and player hand. With this data the <see cref="EntityEquipment"/>^
    /// can the set the item in the hand of the player.
    ///
    /// The class also stores the differen <see cref="EquipmentAnimation"/> in order
    /// to provide the functionalty of playing different animations for an item.
    /// </summary>
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
    public class Equipment : Item
    {
        public delegate void DurationUpdate(float normalizedDuration);
        public event DurationUpdate OnDurationUpdate;

        [Header("Equipment")]
        public ItemType type; 
        public GameObject prefab;

        public bool hasDuration;
        public float duration;
        private float currentDuration;

        [Header("Default item position")]
        public Hand defaultHand;
        public Vector3 defaultPosition;
        public Vector3 defaultRotation;
        public Vector3 defaultDropRotation;

        [Header("Animations")]
        public EquipmentAnimation[] equipmentAnimations;

        void OnEnable()
        {
            currentDuration = duration;
        }

        /// <summary>
        /// Gets triggerd if the user used an item and will update the duration
        /// of the item. If the item is broke the method will also remove the
        /// item from the inventory of the player
        /// </summary>
        /// <returns></returns>
        public bool UseItem()
        {
            currentDuration--;
            OnDurationUpdate?.Invoke(NormalizedDuration);

            if (currentDuration <= 0)
            {
                Player.instance.inventory.RemoveItem(this);
                return true;
            }

            return false;
        }

        public float NormalizedDuration
        {
            get { return currentDuration / duration; }
        }

        public float CurrentDuration
        {
            get { return currentDuration;  }
        }

        public bool IsMeleeWeapon => type == ItemType.Fist || type == ItemType.Knife || type == ItemType.Bottle;
        public bool IsDrink => type == ItemType.Whiskey || type == ItemType.Beer || type == ItemType.Feuersaft;
    }

    [System.Serializable]
    public class EquipmentAnimation
    {
        public int index;
        public Hand hand;

        public bool useSpecifcPosition;
        public bool useSpecificRotation;

        public Vector3 specificPosition;
        public Vector3 specificRotation;
    }

    public enum Hand
    {
        Left,
        Right
    }
}