using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Interactable
{
    public bool movementEnabled = true;
    public Money money;
    public GameObject damagePopup;

    public float lookRadius = 10f;
    public float attackRate = 1f;
    private float attackCooldown = 0f;

    public EntityStats Stats { get; protected set; }
    public EntityCombat Combat { get; protected set; }
    public EnemyAnimator Animator { get; protected set; }

    private Player player;
    private Transform target;
    private NavMeshAgent agent;


    void Start()
    {
        player = Player.instance;
        target = player.player.transform;
        agent = GetComponent<NavMeshAgent>();
        Combat = GetComponent<EntityCombat>();
        Animator = GetComponent<EnemyAnimator>();

        Stats = GetComponent<EntityStats>();
        Stats.OnTakeDamage += OnTakeDamage;
        Stats.OnDeath += Death;
    }

    void Update()
    {
        if (!Stats.IsDead)
        {
            attackCooldown -= Time.deltaTime;
    

            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                if (movementEnabled) agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance && attackCooldown <= 0f)
                {
                    double velocity = agent.velocity.magnitude / agent.speed; 
                    if (velocity == 0f)
                    {
                        PlayerStats playerStats = player.stats;
                        PlayerCombat playerCombat = player.combat;
                        if (playerStats != null && playerCombat != null && !playerStats.IsDead)
                        {
                            attackCooldown = 1f / attackRate;
                            Animator.OnPrimary();

                            if (!playerCombat.IsBlocking) Combat.Attack(playerStats);
                        }
                    }
                } 

                FaceTarget();
            }
        }
    }

    public override void Interact()
    {
        if (Stats.IsDead) return;

        EntityCombat combat = Player.instance.combat;
        combat.Attack(Stats);
    }

    private void OnTakeDamage(double damage)
    {
        if (Stats.IsDead) return;
        if (damagePopup) ShowDamagePopup(damage);
    }

    private void Death()
    {
        agent.enabled = false;
        Animator.OnDeath();

        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 2f);
    }

    private void ShowDamagePopup(double damage)
    {
        GameObject popup = Instantiate(damagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = damage.ToString();
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
