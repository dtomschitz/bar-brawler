using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class UsableItem : ScriptableObject
{
    new public string name = "Neues Item";
    public Sprite icon = null;

    public virtual void Use()
    {

    }

    public virtual void Remove()
    {

    }
}
