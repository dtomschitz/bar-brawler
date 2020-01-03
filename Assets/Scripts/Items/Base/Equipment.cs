using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item
{
    public Items itemType;
    
    public GameObject prefab;
    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 dropRotation;
}
