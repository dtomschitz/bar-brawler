using UnityEngine;
using UnityEngine.UI;
using Items;

public class EnemyStats : EntityStats
{
    public Image healthBar;
    public GameObject damagePopup;

    public override void Damage(float damage, Equipment item = null)
    {
        base.Damage(damage, item);

        if (IsDead) return;
        healthBar.fillAmount = CurrentHealth / maxHealth;

        if (damagePopup) ShowDamagePopup(damage);

        Statistics.instance.AddDamage(damage);
    }

    public void ShowDamagePopup(double damage)
    {
        GameObject popup = Instantiate(damagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = damage.ToString();
    }

    /// <summary>
    /// Loads the given <see cref="EnemyStatsConfig"/> for the enemy.
    /// </summary>
    /// <param name="config">The config which should be loaded.</param>
    public void Init(EnemyStatsConfig config)
    {
        if (config != null)
        {
            if (config.minHealth > 0f && config.maxHealth > 0f)
            {
                float health = Random.Range(config.minHealth, config.maxHealth);
                maxHealth = health;
                CurrentHealth = health;
            }

            if (config.damage > 0f) damage = config.damage;
        }
    }
}
