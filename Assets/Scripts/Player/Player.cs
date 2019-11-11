using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singelton

    public static Player instace;

    void Awake()
    {
        instace = this;
    }

    #endregion;

    public PlayerStats stats;
    public CharacterCombat combat;
    public GameObject player;

    void Start()
    {
        stats.OnHealthIsZero += Die;
    }

    void Die()
    {
        //TODO: Playe Die 
    }
}
