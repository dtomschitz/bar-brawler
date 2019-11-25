using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singelton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public PlayerStats stats;
    public Inventory inventory;
    public EntityCombat combat;
    public GameObject player;

    public int money;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        inventory = player.GetComponent<Inventory>();
        combat = player.GetComponent<EntityCombat>();
        stats.OnHealthIsZero += Die;
    }

    void Die()
    {
        //TODO: Playe Die 
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}
