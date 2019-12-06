using UnityEngine;

public class Revolver : Weapon
{
    public Bullet bullet;
    public Transform muzzle;
    public bool isFiring;
    public float bulletSpeed;

    private Camera cam;
    private Inventory inventory;

    private void Start()
    {
        cam = Camera.main;
        inventory = Player.instance.inventory;
    }

    public override void OnInteract()
    {
        base.OnInteract();

        /* Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit, 100))
         {

         }*/

        Shoot();
    }

    private void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
        newBullet.speed = bulletSpeed;
    }
}
