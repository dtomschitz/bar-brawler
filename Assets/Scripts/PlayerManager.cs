using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singelton

    public static PlayerManager instace;

    void Awake()
    {
        instace = this;
    }

    #endregion;

    public GameObject player;
}
