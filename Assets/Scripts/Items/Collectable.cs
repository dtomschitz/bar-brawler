using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Item item;
    public bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            item.OnUse();
            Player.instance.inventory.AddItem(item);
            OnCollection();
        }
    }

    public virtual void OnCollection()
    {
        Destroy(gameObject);
    }
}
