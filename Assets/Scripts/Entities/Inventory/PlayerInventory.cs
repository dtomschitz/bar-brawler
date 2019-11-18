using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
}
