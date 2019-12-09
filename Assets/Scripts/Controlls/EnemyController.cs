using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRate = 1f;
    private float attackCooldown = 0f;

    private Transform target;
    private NavMeshAgent agent;
    private EntityCombat combat;
    private EnemyAnimator animator;

    void Start()
    {
        target = Player.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EntityCombat>();
        animator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance && attackCooldown <= 0f)
            {
                EntityStats playerStats = target.GetComponent<EntityStats>();
                if (playerStats != null)
                {
                    attackCooldown = 1f / attackRate;
                    combat.Attack(playerStats);
                    animator.OnAttack();
                }
            }
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
