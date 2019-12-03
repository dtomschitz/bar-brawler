using UnityEngine;

public class Revolver : Weapon
{
    public override void OnCollection()
    {
        base.OnCollection();
        Debug.Log("Revolver collected");
    }
}
