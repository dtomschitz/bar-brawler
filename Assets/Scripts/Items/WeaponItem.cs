using System;
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

        public float knockbackForce = 10f;

        private float primaryCooldown = 0f;
        private float secondaryCooldown = 0f;

        private Coroutine primaryRoutine;
        private Coroutine secondaryRoutine;

        void Update()
        {
            primaryCooldown -= Time.deltaTime;
            secondaryCooldown -= Time.deltaTime;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject != owner.gameObject && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
            {
                if (owner.combat.IsAttacking)
                {
                    Entity entity = other.gameObject.GetComponent<Entity>();
                    if (entity != null) OnHit(entity);
                }
            }
        }

        public override void OnPrimary()
        {
            base.OnPrimary();

            if (owner.combat.IsDrinking || owner.combat.IsAttacking) return;

            if (primaryCooldown <= 0f)
            {
                primaryCooldown = 1f / primaryAttackRate;
                owner.animator.OnPrimary();
            }
        }

        public override void OnSecondary()
        {
            base.OnSecondary();

            if (owner.combat.IsDrinking || owner.combat.IsAttacking) return;

            if (secondaryCooldown <= 0f && owner.combat.CurrentMana >= secondaryManaRequired)
            {
                secondaryCooldown = 1f / secondaryAttackRate;
                owner.animator.OnSecondary();
            }
        }

        public virtual void StartPrimaryRoutine(IEnumerator routine)
        {
            if (primaryRoutine != null)
            {
                StopCoroutine(primaryRoutine);
                primaryRoutine = null;
            }
        }

        public virtual void StartSecondaryRoutine(IEnumerator routine)
        {
            if (secondaryRoutine != null)
            {
                StopCoroutine(secondaryRoutine);
                secondaryRoutine = null;
            }
        }

        private void Cooldown(float cooldown, float requiredMana, float currentMana, Action trueCallback, Action falseCallback)
        {
            if (cooldown <= 0f && currentMana >= requiredMana) trueCallback();
            else falseCallback();
        }
    }
}