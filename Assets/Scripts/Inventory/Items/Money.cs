using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Item
{
    public int amount;

    public override void OnInteract()
    {
        base.OnInteract();
        Player.instance.AddMoney(amount);
        Destroy(gameObject);
    }
}
