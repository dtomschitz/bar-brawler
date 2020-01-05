using System;
using UnityEngine;

public class HitColider : MonoBehaviour
{
    public delegate void Hit(Enemy enemy);
    public event Hit OnHit;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player player = Player.instance;
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null && enemy != player && player.combat.IsAttacking)
            {
                //enemy.Interact();
                OnHit?.Invoke(enemy);
            }
        }
    }
}
