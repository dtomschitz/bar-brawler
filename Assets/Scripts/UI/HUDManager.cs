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

    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;

    public void DisplayHotbar(bool visible)
    {
        hotbar.gameObject.SetActive(visible);
    }

    public void DisplayHealthBar(bool visible)
    {
        healthBar.gameObject.SetActive(visible);
    }

    public void DisplayManaBar(bool visible)
    {
        manaBar.gameObject.SetActive(visible);
    }
}
