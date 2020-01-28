using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public delegate void Hit(Entity entity);
    public event Hit OnHit;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            OnHit?.Invoke(other.gameObject.GetComponent<Entity>());

           /* Player player = Player.instance;
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null && enemy != player && player.combat.IsAttacking)
            {
                OnHit?.Invoke(enemy);
            }*/
        }
    }
}
