using Utils;

public class ManaBar : ShrinkBar
{
    private EntityCombat combat;

    void Start()
    {
        combat = Player.instance.combat;
        combat.OnManaAdded += OnManaAdded;
        combat.OnManaUsed += OnManaUsed;
    }

    public void OnManaAdded()
    {
        SetBarFillAmount(combat.ManaNormalized);
        AlignBars();
    }

    public void OnManaUsed()
    {
        ResetShrinkTimer();
        SetBarFillAmount(combat.ManaNormalized);
    }
}
