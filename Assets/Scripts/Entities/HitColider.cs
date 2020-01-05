using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColider : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player player = Player.instance;
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null && enemy != player && player.equipment.CurrentItem is WeaponItem)
            {
                enemy.Interact();
            }
        }
    }
}
