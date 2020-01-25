using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Equipment
    {
        [Header("Damage")]
        public int damage;
    }
}