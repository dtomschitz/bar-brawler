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
    public Image healthBar;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateMoneyText(int amount)
    {
        moneyText.text = "$" + amount;
    }
}
