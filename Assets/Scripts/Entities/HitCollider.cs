using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public delegate void Hit(Enemy enemy);
    public event Hit OnHit;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT11");


            Player player = Player.instance;
            Enemy enemy = other.gameObject.GetComponent<Enemy>();


            Debug.Log(player.combat.IsAttacking);

            if (enemy != null && enemy != player)
            {
                Debug.Log("HIT");
                OnHit?.Invoke(enemy);
            }
        }
    }
}
