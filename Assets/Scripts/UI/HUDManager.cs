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
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;

    public GameObject gameOverUI;


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

    public void DisplayWaveInfo(bool visible)
    {
        waveInfo.gameObject.SetActive(visible);
    }

    public void DisplayInteractionHint(bool visible)
    {
        interactionHint.gameObject.SetActive(visible);
    }

    public void DisplayGameOverUI(bool visible)
    {
        DisplayHealthBar(!visible);
        DisplayManaBar(!visible);
        DisplayHotbar(!visible);
        DisplayWaveInfo(!visible);
        DisplayInteractionHint(visible);
        gameOverUI.SetActive(visible);
    }
}
