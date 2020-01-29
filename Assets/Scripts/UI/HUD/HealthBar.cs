using Utils;

public class HealthBar : ShrinkBar
{
    private EntityStats stats;

    void Start()
    {
        stats = Player.instance.stats;
        stats.OnDamaged += OnDamaged;
        stats.OnHealed += OnHealed;
    }

    public void OnDamaged(float damage)
    {
        SetFillAmount(stats.HealthNormalized);
    }

    private void OnHealed(float amount)
    {
        SetFillAmount(stats.HealthNormalized);
    }
}