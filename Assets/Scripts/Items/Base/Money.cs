using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Money Item", menuName = "Items/Money")]
public class Money : Item
{
    public int amount;

    public override void OnInteract()
    {
        base.OnInteract();
        Player.instance.AddMoney(amount);
    }
}
