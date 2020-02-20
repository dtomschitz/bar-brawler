using System;
using Utils;

/// <summary>
/// Class <c>ManaBar</c> manages the visualisation of the players mana bar
/// by subscribing to the <see cref="EntityCombat.OnManaAdded"/> and
/// <see cref="EntityCombat.OnManaUsed"/> events.
/// </summary>
public class ManaBar : ShrinkBar
{
    private EntityCombat combat;

    void Start()
    {
        combat = Player.instance.combat;
        if (combat == null) throw new NullReferenceException("Entity combat class cannot be null");

        combat.OnManaAdded += OnManaAdded;
        combat.OnManaUsed += OnManaUsed;
    }

    /// <summary>
    /// Gets called if the player received some mana and updates the mana bar
    /// accordingly.
    /// </summary>
    /// <param name="amount">The amount of mana points the player received.</param>
    public void OnManaAdded()
    {
        SetBarFillAmount(combat.ManaNormalized);
        AlignBars();
    }

    /// <summary>
    /// Gets called if the player spent some mana and updates the mana bar
    /// accordingly.
    /// </summary>
    /// <param name="amount">The amount of mana points the player spent.</param>
    public void OnManaUsed()
    {
        ResetShrinkTimer();
        SetBarFillAmount(combat.ManaNormalized);
    }
}
