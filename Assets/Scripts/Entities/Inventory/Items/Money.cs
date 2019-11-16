using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectable
{
    public int amount = 10;

    private void Awake()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider)
        {
            collider.radius = radius;
        }
    }

    public override void Interact()
    {
        Player.instace.AddMoney(amount);
    }
}
