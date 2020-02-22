using System.Collections;
using UnityEngine;

namespace Items
{
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