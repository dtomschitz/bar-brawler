using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectable
{
    public int amount = 10;

    public override void OnCollection()
    {
        Player.instance.AddMoney(amount);
    }
}
