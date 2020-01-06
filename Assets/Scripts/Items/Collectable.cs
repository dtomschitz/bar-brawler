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
            item.OnCollection();
            OnCollection();
           
        }
    }

    public virtual void OnCollection()
    {
        Destroy(gameObject);
    }
}
