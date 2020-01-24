namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnPrimary()
        {
            if (combat.state == CombatState.BLOCKING) return;
            base.OnPrimary();
        }

        public override void OnSecondary()
        {
            if (combat.state == CombatState.ATTACKING) return;
            base.OnSecondary();
        }
    }
}