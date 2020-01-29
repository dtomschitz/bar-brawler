using UnityEngine;
using UnityEngine.UI;
using Wave;
using Shop;
public class Statistics : MonoBehaviour
{
    #region Singelton

    public static Statistics instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public Text roundsText;
    public Text Kills;
    public Text Damage;
    public Text MoneySpend;

    void Start()
    {
        WaveSpawner.rounds = 0;
        Enemy.enemyDeathCounter = 0;
        EnemyStats.damageTaken = 0;
        ShopItem.spendMoney = 0;
    }

    public void OnEnable()
    {
        roundsText.text = WaveSpawner.rounds.ToString();
        Kills.text = Enemy.enemyDeathCounter.ToString();
        Damage.text = Mathf.Floor(EnemyStats.damageTaken).ToString();
        MoneySpend.text = ShopItem.spendMoney.ToString();
    }
}
