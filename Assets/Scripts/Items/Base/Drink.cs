using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink", menuName = "Items/Drink")]
public class Drink : Equipment
{
    public int healingAmount;

    public override void OnUse()
    {
        base.OnUse();
        Player.instance.stats.Heal(healingAmount);
       // Player.instance.inventory.RemoveItem(this);
    }
}
