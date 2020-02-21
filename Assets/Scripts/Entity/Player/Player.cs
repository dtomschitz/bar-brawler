using UnityEngine;

/// <summary>
/// Class <c>Player</c> extends the <c>Entity</c> class an overrides some of the
/// base methods in order to handle player specific stuff.
/// </summary>
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

    public int CurrentBalance { get; set; } = 300;

    /// <summary>
    /// This method gets called if the player died and will then trigger the
    /// death animation, the victory animation for all enemies and sets the
    /// <see cref="GameState"/> to <see cref="GameStateType.GameOver"/>.
    /// </summary>
    public override void OnDeath()
    {
        base.OnDeath();
        animator.OnDeath();

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies != null)
        {
            foreach (Enemy enemy in enemies) enemy.animator.OnVictory();
        }

        GameState.instance.SetState(GameStateType.GameOver);
    }

    /// <summary>
    /// Adds the given amount of money to the current balance <see cref="Current Balance"/>,
    /// triggers the <see cref="OnMoneyReceived"/> event and plays the <see cref="Sound.ReceiveMoney"/>.
    /// </summary>
    /// <param name="amount">The ammount of money the played received.</param>
    public void AddMoney(int amount)
    {
        CurrentBalance += amount;
        OnMoneyReceived?.Invoke(amount, CurrentBalance);
        AudioManager.instance.PlaySound(Sound.ReceiveMoney);
    }

    /// <summary>
    /// Removes the given amount of money from the current balance <see cref="Current Balance"/>
    /// and triggers the <see cref="OnMoneySpend"/> event.
    /// <param name="amount">The ammount of money the played spent.</param>
    public void RemoveMoney(int amount)
    {
        CurrentBalance -= amount;
        OnMoneySpend?.Invoke(amount, CurrentBalance);
    }
}