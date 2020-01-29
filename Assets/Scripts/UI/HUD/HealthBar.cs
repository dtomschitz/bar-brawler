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

/*public class HealthBar : MonoBehaviour
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

public class ShrinkBar : MonoBehaviour
{
    public Image barImage;
    public Image shrinkBarImage;

    public float maxShrinkTimer = 0.6f;

    private float shrinkTimer;

    void Update()
    {
        shrinkTimer -= Time.deltaTime;
        if (shrinkTimer < 0)
        {
            if (barImage.fillAmount < shrinkBarImage.fillAmount)
            {
                float shrinkSpeed = 1f;
                shrinkBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }
    }

    protected void SetFillAmount(float amount)
    {
        shrinkTimer = maxShrinkTimer;
        barImage.fillAmount = amount;
    }
}*/
