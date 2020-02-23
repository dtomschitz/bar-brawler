using UnityEngine;

namespace Items
{
    /// <summary>
    /// Class <c>WeaponItem</c> is used to handle weapon specific functionalities such
    /// as an cooldown of the given item. Additionaly the mechanic of the hit
    /// detection of an item is implemented in this class. 
    /// </summary>
    public class WeaponItem : Equippable
    {
        public float primaryAttackRate = 20f;
        public float secondaryAttackRate = 20f;

        public float primaryManaRequired = 0f;
        public float secondaryManaRequired = 0f;

        private float primaryCooldown = 0f;
        private float secondaryCooldown = 0f;

        private bool hasCollided = false;

        void Update()
        {
            primaryCooldown -= Time.deltaTime;
            secondaryCooldown -= Time.deltaTime;
        }

        /// <summary>
        /// Gets triggered if the entity hits another entity an will call the
        /// <see cref="OnHit(Entity)"/> method.
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter(Collider other)
        {
            if (hasCollided) return;
            if (owner != null && other.gameObject != owner.gameObject && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
            {
                if (owner.combat.IsAttacking)
                {
                    Entity entity = other.gameObject.GetComponent<Entity>();
                    if (entity != null) OnHit(entity);

                    hasCollided = true;
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (!hasCollided) return;
            if (owner != null && other.gameObject != owner.gameObject && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
            {
                hasCollided = false;
            }
        }

        /// <summary>
        /// This method is used to update the duration of the used item and attacks
        /// the stats of the attacked entity.
        /// </summary>
        /// <param name="entity">The entity which got attacked.</param>
        public virtual void OnHit(Entity entity)
        {
            if (entity.combat.IsBlocking && owner.equipment.CurrentEquipment.type == ItemType.Fist) return;
            if (entity is Enemy && owner is Player && item.hasDuration)
            {
                bool isDestroyed = item.UseItem();
                if (isDestroyed) return;
            }

            entity.OnHit(owner, item);
        }

        /// <summary>
        /// Overrides the base method and adds an cooldown mechanic to it.
        /// </summary>
        public override void OnPrimary()
        {
            base.OnPrimary();

            if (owner != null && owner.combat != null && (owner.combat.IsDrinking || owner.combat.IsAttacking || owner.combat.IsStunned)) return;
            if (primaryCooldown <= 0f)
            {
                primaryCooldown = 1f / primaryAttackRate;
                owner.animator.OnPrimary();
            }
        }

        /// <summary>
        /// Overrides the base method and adds an cooldown mechanic to it.
        /// </summary>
        public override void OnSecondary()
        {
            base.OnSecondary();

            if (owner != null && owner.combat != null && (owner.combat.IsDrinking || owner.combat.IsAttacking || owner.combat.IsStunned)) return;
            if (secondaryCooldown <= 0f && owner.combat.CurrentMana >= secondaryManaRequired)
            {
                secondaryCooldown = 1f / secondaryAttackRate;
                owner.animator.OnSecondary();
            }
        }
    }
}