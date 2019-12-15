using UnityEngine;

public class Equippable : Collectable
{
    void Start()
    {
        if (!(item is Equipment))
        {
            throw new UnityException("Item is not of the type Equipment");
        }
    }

    public virtual void OnInteract()
    {
    }

    public void OnEquip()
    {
        isCollected = true;
    }

    public virtual void OnDrop()
    {
        isCollected = false;
        /*RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            equipmentObject.SetActive(true);
            equipmentObject.transform.position = hit.point;
            equipmentObject.transform.eulerAngles = item.dropRotation;
        }*/
    }
}