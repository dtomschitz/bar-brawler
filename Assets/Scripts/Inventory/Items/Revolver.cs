using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : EquippableItem
{
    public override void OnCollection()
    {
        base.OnCollection();
        Debug.Log("Revolver collected");
    }
}
