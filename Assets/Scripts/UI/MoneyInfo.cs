using System.Collections;
using System.Collections.Generic;
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

    public void OnMoneyReceived(int currentBalance)
    {
        InstantiateMoneyText(moneyRecived);
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .7f));
    }

    public void OnMoneySpend(int currentBalance)
    {
        InstantiateMoneyText(moneySpend);
        StartCoroutine(MoneyUpdateRoutine(currentBalance, .1f));
    }

    private void InstantiateMoneyText(GameObject gameObject)
    {
        GameObject popup = Instantiate(gameObject, transform);
        Destroy(popup, destroyText);
    }

    private IEnumerator MoneyUpdateRoutine(int currentBalance, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentBalanceText.text = "$" + currentBalance;

    }
}
