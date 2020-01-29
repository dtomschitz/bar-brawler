using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Image damagedBarImage;
    public float maxHealthShrinkTimer = 0.6f;

    private EntityStats stats;
    private float healthShrinkTimer;

    void Start()
    {
        stats = Player.instance.stats;
        stats.OnDamaged += OnDamaged;
        stats.OnHealed += OnHealed;
    }

    void Update()
    {
        healthShrinkTimer -= Time.deltaTime;
        if (healthShrinkTimer < 0)
        {
            if (healthBarImage.fillAmount < damagedBarImage.fillAmount)
            {
                float shrinkSpeed = 1f;
                damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }
    }

    public void OnDamaged(float damage)
    {
        healthShrinkTimer = maxHealthShrinkTimer;
        SetHealth(stats.HealthNormalized);
    }

    private void OnHealed(float amount)
    {
        healthShrinkTimer = maxHealthShrinkTimer;
        SetHealth(stats.HealthNormalized);
    }

    private void SetHealth(float health)
    {
        healthBarImage.fillAmount = health;
    }
}
