using UnityEngine;

namespace Items
{
    /// <summary>
    /// Class <c>Drink</c> is used to store all necessary information for a
    /// consumable item.
    /// </summary>
    [CreateAssetMenu(fileName = "New Drink", menuName = "Items/Drink")]
    public class Drink : Equipment
    {
        [Header("Drink")]
        public int healingAmount;
        public float healingDelay;
    }
}