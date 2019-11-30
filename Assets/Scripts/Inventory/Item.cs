using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    new public string name;
    public Sprite icon;
    public ItemType itemType;
    public bool addToInventory = true;

    public virtual void OnInteract()
    {
    }

    public virtual bool CanInteract(Collider other)
    {
        return true;
    }

    public virtual void OnCollection()
    {
        //Destroy(gameObject);
        if (!addToInventory) Destroy(gameObject);
        gameObject.SetActive(false);
    }
}

public class EquippableItem : Item
{
    public Slot slot;

    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 dropRotation;

    public virtual void OnUse()
    {
        transform.localPosition = pickPosition;
        transform.localEulerAngles = pickRotation;
    }

    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
            gameObject.transform.eulerAngles = dropRotation;
        }
    }
}

public enum ItemType
{
    Consumable,
    Weapon
}
