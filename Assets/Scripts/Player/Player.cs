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

    public PlayerControls controls;
    public PlayerStats stats;
    public PlayerCombat combat;
    public PlayerAnimator animator;

    public Inventory inventory;
    public EquipmentManager equipment;

    public GameObject player;

    public int money = 0;

    void Start()
    {
        stats.OnDeath += OnDeath;
        stats.OnTakeDamage += OnTakeDamage;
        HUDManager.instance.UpdateMoneyText(money);
    }

    private void OnDeath()
    {
        controls.enableMovement = false;
        animator.OnDeath();
    }

    private void OnTakeDamage()
    {
        //HUDManager.instance.UpdateHealthBar(stats.CurrentHealth, stats.maxHealth);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        HUDManager.instance.UpdateMoneyText(money);
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        HUDManager.instance.UpdateMoneyText(money);
    }
}