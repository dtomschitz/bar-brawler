using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Item
{
    public int amount;

    public override void OnCollision()
    {
        base.OnCollision();
        Player.instance.AddMoney(amount);
        Destroy(gameObject);
    }
}
