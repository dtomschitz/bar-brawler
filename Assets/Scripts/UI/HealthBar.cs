using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = Player.instance.stats;
    }

    void Update()
    {
        healthBarImage.fillAmount = playerStats.NormalizedHealth;
    }
}
