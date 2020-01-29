using System.Collections;
using UnityEngine;

public class DamageOverlay : MonoBehaviour
{
    public PlayerStats stats;
    private Animator animator;

    //private Coroutine damageOverlayRoutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        stats.OnDamaged += OnTakeDamage;
    }

    public void OnTakeDamage(float damage)
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
