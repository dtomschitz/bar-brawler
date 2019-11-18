﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public UsableItem item;

    private void Awake()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider)
        {
            collider.radius = 1f;
        }
    }

    public virtual void OnCollection()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnCollection();
            bool itemAdded = PlayerInventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
