using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{

    new public string name = "Neues Item";
    public Sprite icon = null;

    public virtual void Use() { }
}