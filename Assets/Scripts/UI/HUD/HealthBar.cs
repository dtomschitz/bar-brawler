using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerStats playerStats;

    void Start()
    {
        if (!healthBarImage)
        {
            throw new NullReferenceException("Healthbar image is not set!");
        }
    }

    void Update()
    {
        if (playerStats) healthBarImage.fillAmount = playerStats.NormalizedHealth;
    }
}
