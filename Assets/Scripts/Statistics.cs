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

    private int kills;
    private int moneySpend;
    private int damage;

    public void AddKill()
    {
        kills++;
    }

    public void SpendMoney(int amount)
    {
        moneySpend += amount;
    }

    public void DealDamage(int amount)
    {
        damage += amount;
    }
}
