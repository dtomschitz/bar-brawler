using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Item
{
    //private Item item;
    private bool isCollected;
    void Start()
    {
        //item = GetComponent<Item>();
        isCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {

            isCollected = true;
            OnCollision();
            /*if (this is EquippableItem)
            {
                (item as EquippableItem).OnCollection();
            }*/
        }
    }

    public virtual void OnCollision()
    {
        gameObject.SetActive(false);
    }
}
