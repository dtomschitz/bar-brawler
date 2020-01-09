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

    //private float waitForSeconds = 1;
    //private bool gameIsOver = false;
   // public GameObject gameOverUI;

    void Start()
    {
        stats.OnDeath += OnDeath;
        HUDManager.instance.UpdateMoneyText(money);
    }

    void Update()
    {
        /*if (gameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("y"))
        {
            EndGame();
        }*/
    }

    private void OnDeath()
    {
        controls.enableMovement = false;
        animator.OnDeath();
        EndGame();
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

    void EndGame()
    {
        //gameIsOver = true;
        //gameOverUI.SetActive(true);
    }
}