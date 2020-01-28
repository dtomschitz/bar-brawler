using System.Collections;
using UnityEngine;

namespace Items
{
    public class Knife : WeaponItem
    {
        [Header("Knife Attributes")]
        public float bleedOutDamage = 2f;
        public float bleedOutTime = 10f;
        public float timeBetweenDamage = 1f;

        public override void OnPrimary()
        {
            base.OnPrimary();
        }

        public override void OnHit(Entity entity)
        {
            base.OnHit(entity);
            FindObjectOfType<AudioManager>().Play("KnifeHit");
            StartCoroutine(KnifeBleedOut(entity));
        }

        private IEnumerator KnifeBleedOut(Entity entity)
        {
            var pastTime = 0f;
            while (pastTime < bleedOutTime)
            {
                entity.stats.Damage(bleedOutDamage);
                pastTime++;
                yield return new WaitForSeconds(timeBetweenDamage);
            }
        }
    }
}