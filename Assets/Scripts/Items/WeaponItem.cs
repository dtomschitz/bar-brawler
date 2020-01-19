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

        protected PlayerCombat combat;
        protected PlayerAnimator animator;

        void Start()
        {
            combat = Player.instance.combat;
            animator = Player.instance.animator;

            HitCollider hitColider = GetComponent<HitCollider>();
            if (hitColider) hitColider.OnHit += OnHit;
        }

        void Update()
        {
            primaryCooldown -= Time.deltaTime;
            secondaryCooldown -= Time.deltaTime;
        }

        public override void OnInteractPrimary()
        {
            base.OnInteractPrimary();

            Cooldown(primaryCooldown, primaryManaRequired, combat.CurrentMana,
                () =>
                {
                    primaryCooldown = 1f / primaryAttackRate;
                    OnPrimaryAccomplished();
                },
                () => combat.state = CombatState.IDLE
            );
        }

        public override void OnInteractSecondary()
        {
            base.OnInteractSecondary();

            Cooldown(secondaryCooldown, secondaryManaRequired, combat.CurrentMana,
                () =>
                {
                    secondaryCooldown = 1f / secondaryAttackRate;
                    OnSecondaryAccomplished();
                },
                () => { }
            );
        }

        public virtual void OnPrimaryAccomplished()
        {
        }

        public virtual void OnSecondaryAccomplished()
        {
        }

        public virtual void OnHit(Enemy enemy)
        {
            print("Hit enemy");
            enemy.Interact();
        }

        public virtual void StartPrimaryRoutine(IEnumerator routine)
        {
            if (primaryRoutine != null)
            {
                StopCoroutine(primaryRoutine);
                primaryRoutine = null;
            }

            primaryRoutine = StartCoroutine(routine);
        }

        public virtual void StartSecondaryRoutine(IEnumerator routine)
        {
            if (secondaryRoutine != null)
            {
                StopCoroutine(secondaryRoutine);
                secondaryRoutine = null;
            }
            secondaryRoutine = StartCoroutine(routine);
        }

        public virtual IEnumerator PrimaryRoutine(float seconds = 1f)
        {
            combat.state = CombatState.ATTACKING;
            yield return new WaitForSeconds(seconds);
            combat.state = CombatState.IDLE;
        }

        private void Cooldown(float cooldown, float requiredMana, float currentMana, Action trueCallback, Action falseCallback)
        {
            if (cooldown <= 0f && currentMana >= requiredMana) trueCallback();
            else falseCallback();
        }
    }
}