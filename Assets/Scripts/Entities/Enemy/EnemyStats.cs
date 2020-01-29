using UnityEngine;
using UnityEngine.UI;
using Items;

public class EnemyStats : EntityStats
{
    public Image healthBar;
    public GameObject damagePopup;

    public override void Damage(float damage)
    {
        base.Damage(damage);

        if (IsDead) return;
        healthBar.fillAmount = CurrentHealth / maxHealth;
        if (damagePopup) ShowDamagePopup(damage);
    }

    public void ShowDamagePopup(double damage)
    {
        GameObject popup = Instantiate(damagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = damage.ToString();
    }
}
