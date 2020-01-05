using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    #region Singelton

    public static HUDManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public Text moneyText;

    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;

    public void UpdateMoneyText(int amount)
    {
        moneyText.text = "$" + amount;
    }

    public void DisplayHotbar(bool state)
    {
        hotbar.gameObject.SetActive(state);
    }

    public void DisplayHealthBar(bool state)
    {
        healthBar.gameObject.SetActive(state);
    }

    public void DisplayManaBar(bool state)
    {
        manaBar.gameObject.SetActive(state);
    }
}
