using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Drink", menuName = "Items/Drink")]
    public class Drink : Equipment
    {
        [Header("Drink")]
        public int healingAmount;
        public float healingSpeed;
        public float healingDelay;
    }
}