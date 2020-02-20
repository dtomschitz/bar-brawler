using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>MoneyInfo</c> manages the visualisation of the players balance by
/// subscribing to the <see cref="Player.OnMoneyReceived"/> and
/// <see cref="EntityCombat.OnManaUsed"/> events.
/// </summary>
public class MoneyInfo : MonoBehaviour
{
    public GameObject moneyRecived;
    public GameObject moneySpend;

    public float destroyText;

    private Text currentBalanceText;

    void Start()
    {
        currentBalanceText = GetComponent<Text>();

        Player.instance.OnMoneyReceived += OnMoneyReceived;    
        Player.instance.OnMoneySpend += OnMoneySpend;    
    }

    /// <summary>
    /// Gets called if the player received money through killing some enemies
    /// and updates the visual count accordingly.
    /// </summary>
    /// <param name="amount">The amount of money the player received</param>
    /// <param name="currentBalance">The current balance of the player.</param>
    public void OnMoneyReceived(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneyRecived, amount, "+");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .7f));
    }

    /// <summary>
    /// Gets called if the player spent money through buying items in the shop
    /// and updates the visual count accordingly.
    /// </summary>
    /// <param name="amount">The amount of money the player spent</param>
    /// <param name="currentBalance">The current balance of the player.</param>
    public void OnMoneySpend(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneySpend, amount, "-");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .1f));
    }

    private void InstantiateMoneyText(GameObject gameObject, int amount, string a)
    {
        GameObject popup = Instantiate(gameObject, transform);
        popup.GetComponent<Text>().text = a + amount + "$";
        Destroy(popup, destroyText);
    }

    private IEnumerator MoneyUpdateRoutine(int currentBalance, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentBalanceText.text = "$ " + currentBalance;

    }
}
