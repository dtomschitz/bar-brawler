using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    new public string name;
    public Sprite icon;
    public ItemType type;
    public bool addToInventory = true;

    public virtual void OnCollision()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnInteract()
    {

    }

    public virtual bool CanInteract(Collider other)
    {
        return true;
    }
}

public enum ItemType
{
    Consumable,
    Weapon
}

public enum WeaponType
{
    Fist,
    Revolver,
    Bottle
}
