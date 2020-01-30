using UnityEngine;

public class Player : Entity
{
    #region Singelton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public delegate void MoneyRecived(int amount, int currentBalance);
    public delegate void MoneySpend(int amount, int currentBalance);
    public event MoneyRecived OnMoneyReceived;
    public event MoneySpend OnMoneySpend;

    [Header("Player specific")]
    public PlayerControls controls;
    public Inventory inventory;

    public int CurrentBalance { get; set; }

    public override void OnDeath()
    {
        base.OnDeath();
        animator.OnDeath();

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies != null)
        {
            foreach (Enemy enemy in enemies) enemy.animator.OnVictory();
        }

        GameState.instance.SetState(State.GAME_OVER);
    }

    public void AddMoney(int amount)
    {
        CurrentBalance += amount;
        OnMoneyReceived?.Invoke(amount, CurrentBalance);
        FindObjectOfType<AudioManager>().Play("GetMoney");
    }

    public void RemoveMoney(int amount)
    {
        CurrentBalance -= amount;
        OnMoneySpend?.Invoke(amount, CurrentBalance);
    }
}