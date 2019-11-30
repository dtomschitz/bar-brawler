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
    public Text waveCountText;


    public void UpdateMoneyText(int amount)
    {
        moneyText.text = "$" + amount;
    }

    public void UpdateWaveCountText(int amount)
    {
        waveCountText.text = "Wave " + amount;
    }
}
