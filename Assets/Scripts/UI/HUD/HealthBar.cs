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

    private void OnHealed(float amount)
    {
        SetBarFillAmount(stats.HealthNormalized);
        AlignBars();
    }

    public void OnDamaged(float damage, Equipment item)
    {
        ResetTimer();
        SetBarFillAmount(stats.HealthNormalized);
    }
}