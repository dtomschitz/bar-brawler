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

    public int currentBalance = 0;

    public delegate void MoneyRecived(int amount, int currentBalance);
    public delegate void MoneySpend(int amount, int currentBalance);
    public event MoneyRecived OnMoneyReceived;
    public event MoneySpend OnMoneySpend;

    public PlayerControls controls;
    public PlayerStats stats;
    public PlayerCombat combat;
    public PlayerAnimator animator;
    public Inventory inventory;
    public EquipmentManager equipment;

    void Start()
    {
        controls = gameObject.GetComponent<PlayerControls>();
        stats = gameObject.GetComponent<PlayerStats>();
        combat = gameObject.GetComponent<PlayerCombat>();
        animator = gameObject.GetComponent<PlayerAnimator>();
        inventory = gameObject.GetComponent<Inventory>();
        equipment = gameObject.GetComponent<EquipmentManager>();

        stats.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        animator.OnDeath();
        GameState.instance.SetState(State.GAME_OVER);
    }

    public void AddMoney(int amount)
    {
        currentBalance += amount;
        OnMoneyReceived?.Invoke(amount, currentBalance);
        FindObjectOfType<AudioManager>().Play("GetMoney");
    }

    public void RemoveMoney(int amount)
    {
        currentBalance -= amount;
        OnMoneySpend?.Invoke(amount, currentBalance);
    }
}