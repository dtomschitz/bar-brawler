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

    public int currentBalance = 1000;

    public delegate void MoneyRecived(int amount, int currentBalance);
    public delegate void MoneySpend(int amount, int currentBalance);
    public event MoneyRecived OnMoneyReceived;
    public event MoneySpend OnMoneySpend;

    public PlayerControls controls;
    public PlayerStats stats;
    public PlayerCombat combat;
    public PlayerAnimator animator;
    public Inventory inventory;
    public PlayerEquipment equipment;

    void Start()
    {
        controls = GetComponent<PlayerControls>();
        stats = GetComponent<PlayerStats>();
        combat = GetComponent<PlayerCombat>();
        animator = GetComponent<PlayerAnimator>();
        inventory = GetComponent<Inventory>();
        equipment = GetComponent<PlayerEquipment>();

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