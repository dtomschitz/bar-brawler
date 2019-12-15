using UnityEngine;

public class Equippable : Collectable
{
    public Slot slot;

    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 dropRotation;

    public override void OnCollision()
    {
        base.OnCollision();
        OnCollection();
    }

    public virtual void OnInteract()
    {
    }

    public virtual void OnCollection()
    {
        Player.instance.inventory.AddItem(this);
    }

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