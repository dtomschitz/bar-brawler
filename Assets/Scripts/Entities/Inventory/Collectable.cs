using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public UsableItem item;

    private void Awake()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider)
        {
            collider.radius = radius;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interact();
            Destroy(gameObject);
        }
    }
}
