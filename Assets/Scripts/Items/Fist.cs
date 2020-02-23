namespace Items
{
    /// <summary>
    /// Class <c>Fist</c> implements the blocking and attacking mechanism.
    /// </summary>
    public class Fist : WeaponItem
    {

        /// <summary>
        /// Implements the blocking mechanic of the fist.
        /// </summary>
        public override void OnSecondary()
        {
            if (owner.combat.IsAttacking) return;
            base.OnSecondary();
            owner.combat.SetState(CombatState.FistBlock);
            owner.combat.UseMana(20f);
        }

        /// <summary>
        /// Overrides the method in order to play the right sound if the given
        /// entity got hit successfuly.
        /// </summary>
        /// <param name="entity"></param>
        public override void OnHit(Entity entity)
        {
            base.OnHit(entity);
            AudioManager.instance.PlaySound(Sound.FistHit, entity.transform.position);
        }
    }
}