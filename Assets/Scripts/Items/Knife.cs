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

        public override void OnHit(Entity entity)
        {
            base.OnHit(entity);
            AudioManager.instance.PlaySound(Sound.KnifeHit, entity.transform.position);
            StartCoroutine(KnifeBleedOut(entity));
        }

        private IEnumerator KnifeBleedOut(Entity entity)
        {
            var pastTime = 0f;
            while (pastTime < bleedOutTime)
            {
                if (entity.stats.IsDead) yield break;

                entity.stats.Damage(bleedOutDamage);
                AudioManager.instance.PlaySound(Sound.FistHit, entity.transform.position);

                pastTime++;
                yield return new WaitForSeconds(timeBetweenDamage);
            }
        }
    }
}