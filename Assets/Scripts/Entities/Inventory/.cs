using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Inventory inventory;
    Item currenItem;
    SkinnedMeshRenderer currentMesh;
    public SkinnedMeshRenderer targetMesh;

    public delegate void OnItemChanged(Item newItem, Item oldItem);
    public event OnItemChanged onItemChanged;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    public void Equip(Item item)
    {
        Item oldItem = null;
        if (currenItem != null)
        {
            oldItem = currenItem;
            inventory.AddItem(oldItem);
        }

        if (onItemChanged != null) onItemChanged.Invoke(item, oldItem);

        currenItem = item;
        if (item.prefab)
    }
}
