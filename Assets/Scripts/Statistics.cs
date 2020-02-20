using UnityEngine;

/// <summary>
/// Class <c>Statistics</c> is used to store different values which can increas
/// will the player is playing. This values will be displayed in the <see cref="GameOver"/>
/// screen when the player finally died.
/// </summary>
public class Statistics : MonoBehaviour
{
    #region Singelton

    public static Statistics instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    /// <summary>
    /// The amount of rounds the player survived.
    /// </summary>
    public int SurvivedRounds { get; protected set; }

    /// <summary>
    /// The amount of kills the player made.
    /// </summary>
    public int Kills { get; protected set; }

    /// <summary>
    /// The amount of damage the player dealed
    /// </summary>
    public float DamageCaused { get; protected set; }

    /// <summary>
    /// The amount of money the player spend.
    /// </summary>
    public int SpendMoney { get; protected set; }

    public void AddRound() => SurvivedRounds++;
    public void AddKill() => Kills++;
    public void AddDamage(float damage) => DamageCaused += damage;
    public void AddMoney(int amount) => SpendMoney += amount;
}
