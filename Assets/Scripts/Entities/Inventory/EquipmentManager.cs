using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singelton

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    Equippable currentItem;
    SkinnedMeshRenderer currentMesh;
    public SkinnedMeshRenderer targetMesh;

    public delegate void OnEquipmentChanged(Equippable newItem, Equippable oldItem);
    public event OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;
    void Start()
    {
        inventory = Player.instance.inventory;
    }

    public void Equip(Equippable item)
    {
        Equippable oldItem = null;
        if (currentItem != null)
        {
            oldItem = currentItem;
            inventory.AddItem(oldItem);
        }

        if (onEquipmentChanged != null)  onEquipmentChanged.Invoke(item, oldItem);

        currentItem = item;
        if (item.prefab) AttachToHand(item.prefab);
    }

    public void Unequip(Equippable item)
    {
        if (currentItem != null)
        {
            Equippable oldItem = currentItem;
            inventory.AddItem(oldItem);

            currentItem = null;
            if (currentMesh != null) Destroy(currentMesh.gameObject);

            if (onEquipmentChanged != null) onEquipmentChanged.Invoke(null, oldItem);
        }
    }

    void AttachToHand(SkinnedMeshRenderer mesh)
    {
        if (currentMesh != null) Destroy(currentMesh.gameObject);

        SkinnedMeshRenderer newMesh = Instantiate(mesh) as SkinnedMeshRenderer;
        
    }
}
