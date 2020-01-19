using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
    public class Equipment : Item
    {
        public ItemType itemType;

        public GameObject prefab;
        public Vector3 pickPosition;
        public Vector3 pickRotation;
        public Vector3 dropRotation;
    }
}
