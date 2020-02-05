using System.Collections;
using UnityEngine;
using Items;

public class DamageOverlay : MonoBehaviour
{
    private EntityStats stats;
    private Animator animator;

    //private Coroutine damageOverlayRoutine;

    void Start()
    {
        stats = Player.instance.stats;
        animator = GetComponent<Animator>();
        stats.OnDamaged += OnTakeDamage;
    }

    public void OnTakeDamage(float damage, Equipment item)
    {
        /*if (damageOverlayRoutine != null)
        {
            StopCoroutine(damageOverlayRoutine);
            damageOverlayRoutine = null;
        }

        damageOverlayRoutine = StartCoroutine(ShowDamgeOverlay());*/
        if (GameState.instance.IsInGame)
        {
            StopAllCoroutines();
            StartCoroutine(ShowDamgeOverlay());
        }
    }

    private IEnumerator ShowDamgeOverlay()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("damage", false);
    }
}
