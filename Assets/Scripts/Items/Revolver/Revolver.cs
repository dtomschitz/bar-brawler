using UnityEngine;

namespace Items
{
    public class Revolver : Equippable
    {
        public Bullet bullet;
        public Transform muzzle;
        public MuzzleFlash muzzleFlash;
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

        public override void OnPrimary()
        {
           /* if (Player.instance.inventory.HasMunition)
            {*/
                if (cooldown <= 0f)
                {
                    cooldown = 1f / fireRate;

                    muzzleFlash.Play();

                    Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
                    newBullet.speed = bulletSpeed;

                    Player.instance.inventory.UseMunition();
                   // animator.OnPrimary();
                }
          //  }
        }
    }
}
