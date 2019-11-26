using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Drink")]
public class Drink : Equippable
{
    public int healingAmount;

    public override void Use()
    {
        Player.instance.stats.Heal(healingAmount);
    }
}
