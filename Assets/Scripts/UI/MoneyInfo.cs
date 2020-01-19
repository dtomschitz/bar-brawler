using System.Collections;
using UnityEngine;
using UnityEngine.UI;


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

    public void OnMoneyReceived(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneyRecived, amount, "+");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .7f));
    }

    public void OnMoneySpend(int amount, int currentBalance)
    {
        InstantiateMoneyText(moneySpend, amount, "-");
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .1f));
    }

    private void InstantiateMoneyText(GameObject gameObject, int amount, string a)
    {
        GameObject popup = Instantiate(gameObject, transform);
        popup.GetComponent<Text>().text = a + amount + "$";

        Debug.Log(popup.GetComponent<Text>().text);
        Destroy(popup, destroyText);
    }

    private IEnumerator MoneyUpdateRoutine(int currentBalance, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentBalanceText.text = "$ " + currentBalance;

    }
}
