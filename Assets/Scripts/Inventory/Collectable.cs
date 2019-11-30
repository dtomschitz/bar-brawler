using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Item item;
    private bool isCollected;
    void Start()
    {
        item = GetComponent<Item>();
        isCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            isCollected = true;
            item.OnInteract();
            if (item is EquippableItem)
            {
                EquippableItem i = item as EquippableItem;
                Player.instance.inventory.AddItem(i);
                i.OnCollection();
            }
        }
    }
}
