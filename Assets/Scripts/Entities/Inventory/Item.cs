using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class UsableItem : ScriptableObject
{
    new public string name = "Neues Item";
    public Sprite icon = null;
    public bool addToInventory = true;


    public virtual void Use()
    {

    }

    public virtual void Remove()
    {
        PlayerInventory.instance.RemoveItem(this);
    }
}
