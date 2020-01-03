using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EntityStats))]
public class Enemy : Interactable
{
    public bool movementEnabled = true;
    public Money money;
    //public GameObject DamagePopup;

    public float lookRadius = 10f;
    public float attackRate = 1f;
    private float attackCooldown = 0f;

    private Transform target;
    private NavMeshAgent agent;
    private EntityStats stats;
    private EntityCombat combat;
    private EnemyAnimator animator;

    void Start()
    {
        target = Player.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EntityCombat>();
        animator = GetComponent<EnemyAnimator>();

        stats = GetComponent<EntityStats>();
        stats.OnDeath += Death;
    }

    void Update()
    {
        if (!stats.IsDead)
        {
            attackCooldown -= Time.deltaTime;

            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                if (movementEnabled) agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance && attackCooldown <= 0f)
                {
                    EntityStats playerStats = target.GetComponent<EntityStats>();
                    if (playerStats != null && !playerStats.IsDead)
                    {
                        attackCooldown = 1f / attackRate;
                        combat.Attack(playerStats);
                        animator.OnAttack();
                    }
                }
                FaceTarget();
            }
        }
    }

    public override void Interact()
    {
        if (stats.IsDead) return;

        EntityCombat combat = Player.instance.combat;
        combat.Attack(stats);

        //if (DamagePopup) ShowDamagePopup();
    }

    private void Death()
    {
        agent.enabled = false;
        animator.OnDeath();

        //Instantiate(money, transform.position);
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 2f);
    }


    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
