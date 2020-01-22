﻿using UnityEngine;

public class HitCollider : MonoBehaviour
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
                OnHit?.Invoke(enemy);
            }
        }
    }
}
