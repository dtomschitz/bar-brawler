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

    public GameObject player;

    public int currentBalance = 0;

    public delegate void MoneyRecived(int currentBalance);
    public delegate void MoneySpend(int currentBalance);
    public event MoneyRecived OnMoneyReceived;
    public event MoneySpend OnMoneySpend;

    public PlayerControls controls { get; protected set; }
    public PlayerStats stats { get; protected set; }
    public PlayerCombat combat { get; protected set; }
    public PlayerAnimator animator { get; protected set; }
    public Inventory inventory { get; protected set; }
    public EquipmentManager equipment { get; protected set; }

    public GameObject gameOverUI;

    void Start()
    {
        controls = player.GetComponent<PlayerControls>();
        stats = player.GetComponent<PlayerStats>();
        combat = player.GetComponent<PlayerCombat>();
        animator = player.GetComponent<PlayerAnimator>();
        inventory = player.GetComponent<Inventory>();
        equipment = player.GetComponent<EquipmentManager>();

        stats.OnDeath += OnDeath;
       // HUDManager.instance.UpdateMoneyText(money);
    }

    void Update()
    {
    }

    private void OnDeath()
    {
        controls.enableMovement = false;
        animator.OnDeath();
        EndGame();
    }

    public void AddMoney(int amount)
    {
        currentBalance += amount;
        OnMoneyReceived?.Invoke(currentBalance);
    }

    public void RemoveMoney(int amount)
    {
        currentBalance -= amount;
        OnMoneySpend?.Invoke(currentBalance);
    }

    void EndGame()
    {
        gameOverUI.SetActive(true);
    }
}