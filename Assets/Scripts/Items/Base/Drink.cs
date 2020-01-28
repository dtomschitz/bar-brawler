using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Drink", menuName = "Items/Drink")]
    public class Drink : Equipment
    {
        public int healingAmount;
        public float healingSpeed;
    }
}