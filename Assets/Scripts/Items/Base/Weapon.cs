using UnityEngine;

namespace Items
{
    /// <summary>
    /// Class <c>Weapon</c> is used for all different kinds of weapons and
    /// stores the base damage value of it.
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Equipment
    {
        [Header("Damage")]
        public float damage;
    }
}