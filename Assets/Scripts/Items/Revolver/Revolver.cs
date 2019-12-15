using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    public Bullet bullet;
    public Transform muzzle;
    public float bulletSpeed;
    public float fireRate = 1f;

    private float cooldown = 0f;

    private Camera cam;
    private Inventory inventory;
    private PlayerAnimator animator;

    void Start()
    {
        cam = Camera.main;
        inventory = Player.instance.inventory;
        animator = Player.instance.animator;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (cooldown <= 0f)
        {
            cooldown = 1f / fireRate;

            Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
            newBullet.speed = bulletSpeed;

            animator.OnAttack();
        }
    }
}
