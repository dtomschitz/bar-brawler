using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Item item;
    void Start()
    {
        item = GetComponent<Item>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            item.OnCollection();
            if (item is EquippableItem)
            {
                Player.instance.inventory.AddItem(item as EquippableItem);
            }
        }
    }
}
