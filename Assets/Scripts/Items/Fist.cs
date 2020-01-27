namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnPrimary()
        {
            if (combat.state == CombatState.Fist_Block) return;
            base.OnPrimary();
        }

        public override void OnSecondary()
        {
            if (combat.state == CombatState.Fist_Attack) return;
            base.OnSecondary();
            combat.UseMana();
        }
    }
}