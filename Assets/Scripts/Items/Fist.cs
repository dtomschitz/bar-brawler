namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnSecondary()
        {
            if (owner.combat.IsAttacking) return;
            base.OnSecondary();
            owner.combat.UseMana(20f);
        }
    }
}