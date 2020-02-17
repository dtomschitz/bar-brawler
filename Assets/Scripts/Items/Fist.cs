namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnSecondary()
        {
            if (owner.combat.IsAttacking) return;
            base.OnSecondary();
            owner.combat.SetState(CombatState.Fist_Block);
            owner.combat.UseMana(20f);
        }

        public override void OnHit(Entity entity)
        {
            base.OnHit(entity);
            AudioManager.instance.PlaySound(Sound.FistHit, entity.transform.position);
        }
    }
}