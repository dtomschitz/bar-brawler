using UnityEngine;

public class Statistics : MonoBehaviour
{
    #region Singelton

    public static Statistics instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public int SurvivedRounds { get; protected set; } = 0;
    public int Kills { get; protected set; } = 0;
    public float DamageCaused { get; protected set; } = 0;
    public int SpendMoney { get; protected set; } = 0;

    void Start()
    {
        SurvivedRounds = 0;
        Kills = 0;
        SpendMoney = 0;
        DamageCaused = 0f;

        Debug.Log("Start new game");
    }


    public void AddRound() => SurvivedRounds++;
    public void AddKill() => Kills++;
    public void AddDamage(float damage) => DamageCaused += damage;
    public void AddMoney(int amount) => SpendMoney += amount;
}
