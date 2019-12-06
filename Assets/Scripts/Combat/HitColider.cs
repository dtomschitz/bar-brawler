using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = Player.instance;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && enemy != player && player.combat.IsAttacking())
        {
            enemy.Interact();
        }
    }
}
