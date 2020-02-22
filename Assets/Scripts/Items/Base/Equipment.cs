using UnityEngine;

namespace Items
{
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
        public Vector3 specificDropRotation;
    }

    public enum Hand
    {
        Left,
        Right
    }
}
