using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public UsableItem item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interact();
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
