namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnSecondary()
        {
            if (owner.combat.state == CombatState.Fist_Attack) return;
            base.OnSecondary();
            owner.combat.UseMana();
        }
    }
}