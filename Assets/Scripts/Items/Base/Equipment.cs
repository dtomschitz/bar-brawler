using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
    public class Equipment : Item
    {
        public ItemType type; 
        public GameObject prefab;
        public GameObject itemHelp;

        [Header("Default item position")]
        public Hand defaultHand;
        public Vector3 defaultPosition;
        public Vector3 defaultRotation;
        public Vector3 defaultDropRotation;

        [Header("Animations")]
        public EquipmentAnimation[] equipmentAnimations;

        public bool IsMeleeWeapon => type == ItemType.Fist || type == ItemType.Knife || type == ItemType.Bottle;
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
