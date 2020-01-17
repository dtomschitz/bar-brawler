using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = Player.instance.stats;

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
