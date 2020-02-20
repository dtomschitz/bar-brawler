public class EnemyCombat : EntityCombat
{
    /// <summary>
    /// Loads a preset configurationen for enemis.
    /// </summary>
    /// <param name="config">The combat config which should get loaded.</param>
    public void Init(EnemyCombatConfig config)
    {
        if (config != null)
        {
            if (config.manaRegenerationAmount >= 0f) manaRegenerationAmount = config.manaRegenerationAmount;
            if (config.manaRegenerationSpeed >= 0f) manaRegenerationSpeed = config.manaRegenerationSpeed;
        }
    }
}
