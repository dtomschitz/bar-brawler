using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Revolver : Equippable
    {
        public Bullet bullet;
        public Transform muzzle;
        public ParticleSystem muzzleFlash;
        public float bulletSpeed;
        public float fireRate = 1f;

        private float cooldown = 0f;

        private PlayerAnimator animator;

        void Start()
        {
            animator = Player.instance.animator;
        }

        void Update()
        {
            cooldown -= Time.deltaTime;
        }

        public override void OnInteractPrimary()
        {
            if (Player.instance.inventory.HasAmmunition)

                if (cooldown <= 0f)
                {
                    cooldown = 1f / fireRate;

                    muzzleFlash.Play();

                    Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
                    newBullet.speed = bulletSpeed;

                    Player.instance.inventory.UseAmmunition();
                    animator.OnPrimary();
                }
        }
    }
}
