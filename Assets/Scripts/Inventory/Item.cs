using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Neues Item";
    public Sprite icon = null;
    public bool addToInventory = true;


    public virtual void Use()
    {

    }

    public virtual void Remove()
    {
        Inventory.instance.RemoveItem(this);
    }
}
