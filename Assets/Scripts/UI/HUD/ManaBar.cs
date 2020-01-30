using Utils;

public class ManaBar : ShrinkBar
{
    private EntityCombat combat;

    void Start()
    {
        combat = Player.instance.combat;
        combat.OnManaUsed += OnManaUsed;
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
