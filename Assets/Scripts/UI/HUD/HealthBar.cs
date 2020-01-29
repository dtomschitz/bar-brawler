using Utils;
using Items;

public class HealthBar : ShrinkBar
{
    private EntityStats stats;

    void Start()
    {
        stats = Player.instance.stats;
        stats.OnDamaged += OnDamaged;
        stats.OnHealed += OnHealed;
    }

    public void OnDamaged(float damage, Equipment item)
    {
        SetFillAmount(stats.HealthNormalized);
    }

    private void OnHealed(float amount)
    {
        SetFillAmount(stats.HealthNormalized);
    }
}