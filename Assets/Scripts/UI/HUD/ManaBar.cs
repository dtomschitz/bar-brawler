using Utils;

public class ManaBar : ShrinkBar
{
    private EntityCombat combat;

    void Start()
    {
        combat = Player.instance.combat;
        combat.OnManaUsed += OnManaUsed;
    }

    public void OnManaUsed()
    {
        SetFillAmount(combat.ManaNormalized);
    }
}
