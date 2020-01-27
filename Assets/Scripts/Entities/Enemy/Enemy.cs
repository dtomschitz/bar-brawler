﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Items;

public enum AIState
{
    ATTACK,
    STRAFE,
    AVOID,
    SEEK
}

public class Enemy : Interactable
{
    public bool movementEnabled = true;

    public GameObject damagePopup;
    public GameObject crosshair;

    public float lookRadius = 10f;
    public float attackRate = 1f;
    private float attackCooldown = 0f;

    public bool IsUnderAttack { get; private set; } = false;
    private Coroutine isUnderAttackRoutine;

    [Header("Drops")]
    public int[] moneyDrop;

    public EntityStats Stats { get; protected set; }
    public EntityCombat Combat { get; protected set; }
    public EnemyAnimator Animator { get; protected set; }

    private Player player;
    private Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        player = Player.instance;
        target = player.gameObject.transform;
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
                            if (!IsUnderAttack)
                            {
                                attackCooldown = 1f / attackRate;
                                Animator.OnPrimary();

                                if (!playerCombat.IsBlocking) Combat.Attack(playerStats);
                            }
                        }
                    }
                } 
            }
        }
    }

    public override void Interact()
    {
        if (Stats.IsDead) return;

        PlayerCombat combat = Player.instance.combat;
        combat.Attack(Stats);

        Debug.Log("attack enemie");
    }

    public void OnTakeDamage(double damage)
    {
        if (Stats.IsDead) return;

        if (isUnderAttackRoutine != null)
        {
            StopCoroutine(IsUnderAttackRoutine());
            isUnderAttackRoutine = null;
        }

        isUnderAttackRoutine = StartCoroutine(IsUnderAttackRoutine());

        if (damagePopup) ShowDamagePopup(damage);
    }

    public void Death()
    {
        agent.enabled = false;
        Animator.OnDeath();

        Player.instance.AddMoney(moneyDrop[Random.Range(0, moneyDrop.Length)]);
        Player.instance.combat.AddMana(10f);

        if (TargetAcquisition.instance.CurrentEnemey == this)
        {
            TargetAcquisition.instance.UnselectCurrentEnemy();
        }

        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 2f);
    }

    public void ShowDamagePopup(double damage)
    {
        GameObject popup = Instantiate(damagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = damage.ToString();
    }

    public void SetCrosshairActive(bool active)
    {
        crosshair.SetActive(active);
    }

    private IEnumerator IsUnderAttackRoutine()
    {
        IsUnderAttack = true;
        yield return new WaitForSeconds(.2f);
        IsUnderAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    /*public float moveSpeed = 5.0f;
   public float turnSpeed = 40.0f;

   public float attackDistance = 1.0f;
   public float dangerDistance = 2.0f;

   public float trackSpeed = 0.1f;
   public float attackRate = 10.0f;
   public float attackRateFluctuation = 0.0f;

   public AIState state;

   public EntityStats stats;
   public EnemyCombat combat;
   public EnemyAnimator animator;

   private Vector3 destination;
   private Vector3 moveVec;

   private float lastAttackTime = 0.0f;

   private bool disabled = false;
   private float lastThought = 0.0f;
   private float lastReact = 0.0f;
   private float actualAttackRate = 0.0f;

   private float thinkPeriod = 1.5f;
   private float reactPeriod = 0.4f;

   private Vector3 distance;
   private Vector3 avoidDistance = Vector3.zero;
   private float sqrDistance;
   private float sqrAttackDistance;
   private float sqrDangerDistance;
   private bool engagePlayer = false;
   private float strafeDir = 1.0f;
   private float strafeCooldown = 0f;
   private float strafeRate = 3.0f;

   private Player player;
   private GameObject playerObject;
   private Avoider avoider;
   private NavMeshAgent agent;

   void OnEnable()
   {
       disabled = false;
   }

   void OnDisable()
   {
       disabled = true;
   }

   void Start()
   {
       player = Player.instance;
       agent = gameObject.GetComponent<NavMeshAgent>();
       combat = gameObject.GetComponent<EnemyCombat>();
       animator = gameObject.GetComponent<EnemyAnimator>();
       stats = gameObject.GetComponent<EntityStats>();
       //Stats.OnTakeDamage += OnTakeDamage;
       // Stats.OnDeath += Death;

       actualAttackRate = attackRate + (Random.value - 0.5f) * attackRateFluctuation;
       lastAttackTime = -actualAttackRate;

       avoider = gameObject.GetComponentInChildren<Avoider>();
       if (avoider != null)
       {
           if(avoider != null)
       {
           Physics.IgnoreCollision(GetComponent<Collider>(), avoider.GetComponent<Collider>());
       }
       }

       sqrAttackDistance = Mathf.Pow(attackDistance, 2);
       sqrDangerDistance = Mathf.Pow(dangerDistance, 2);

       lastThought += thinkPeriod * Random.value;
       lastReact += reactPeriod * Random.value;

       StartCoroutine(SummoningSickness());

   }

   void FixedUpdate()
   {

       if (engagePlayer && !combat.IsAttacking)
       {
           OnAttackComplete();
       }

       if (disabled)
       {
           if (player != null)
           {
               if (trackSpeed > 0.0f && combat.IsAttacking && !combat.IsStunned)
               {
                   Vector3 lookVec = player.transform.position - transform.position;
                   //dude.Look(lookVec, trackSpeed);
               }
               lastReact = Time.fixedTime;
               UpdateDistance();
           }
           return;
       }

       if (strafeCooldown > 0.0f)
       {
           strafeCooldown -= Time.fixedDeltaTime;
       }

       if (player == null || (Time.fixedTime - lastThought) > thinkPeriod)
       {
           lastThought = Time.fixedTime;
           Think();
       }

       if (player == null) return;
       if ((Time.fixedTime - lastReact) > reactPeriod) React();

       UpdateDistance();

       bool shouldAvoid = (avoidDistance != Vector3.zero && sqrDistance <= sqrDangerDistance);
       bool shouldStrafe = (!shouldAvoid && !engagePlayer && sqrDistance <= sqrAttackDistance);
       bool shouldAttack = (engagePlayer && sqrDistance <= sqrAttackDistance);


       if (shouldAvoid)
       {
           state = AIState.AVOID;
           Avoid(avoidDistance);
       }
       else if (shouldAttack)
       {
           Debug.Log("Attack");
           state = AIState.ATTACK;

           Attack(player.transform.position);
       }
       else if (shouldStrafe)
       {
           state = AIState.STRAFE;

           Debug.Log("Strafe");
           Strafe(player.transform.position);
       }
       else
       {
           state = AIState.SEEK;
           Debug.Log("Seek");
           Seek(distance);
       }
   }

   private void UpdateDistance()
   {
       distance = (destination - transform.position);
       sqrDistance = distance.sqrMagnitude;
       if (sqrDistance > sqrAttackDistance) OnAttackComplete();
   }

   private void Think()
   {
       playerObject = GetPlayer();
       if (playerObject == null) return;

       player = Player.instance;

       if (player != null && player.stats.IsDead) return;
       if (avoider != null && avoider.enemy != null)
       {
           avoidDistance = avoider.enemy.transform.position - transform.position;
           avoidDistance = Vector3.Slerp(distance.normalized, avoidDistance.normalized, 0.5f);
       } else
       {
           avoidDistance = Vector3.zero;
       }

       if (!engagePlayer && strafeCooldown <= 0f)
       {
           strafeCooldown = strafeRate;
           strafeDir = 1.0f;
           if (Random.value > 0.5f) strafeDir = -1.0f;
       }
   }

   private void React()
   {
       lastReact = Time.fixedTime;
       distance = (destination - transform.position);
       sqrDistance = distance.sqrMagnitude;

       if (sqrDistance != 0 && sqrDistance <= sqrAttackDistance)
       {
           if (!engagePlayer)
           {
               player.combat.OnRequestAttack(gameObject);
           }
       }
   }

   public void OnAllowAttack(GameObject target)
   {
       if (player != null && target == player.gameObject) engagePlayer = true;
   }

   private void OnAttackComplete()
   {
       engagePlayer = false;
       if (player != null)
       {
           player.combat.OnCancelAttack(gameObject);
       }
   }

   private void Avoid(Vector3 distance)
   {
       Move(distance * -100);
   }

   private void Strafe(Vector3 playerPosition)
   {
       if (engagePlayer)
       {
           OnAttackComplete();
       }

       Vector3 offset = transform.position - playerPosition;
       Vector3 direction = Vector3.Cross(offset, Vector3.up);
       Debug.Log(gameObject.name + ": Strafe");
       agent.SetDestination(transform.position + direction);
   }

   private void Seek(Vector3 distance)
   {
       Move(distance);
   }

   private void Move(Vector3 distance)
   {
       if (engagePlayer)
       {
           OnAttackComplete();
       }

       // can't move if I'm getting pushed around
       // if (dude.GetForce() != Vector3.zero) return;

       destination = player.transform.position;
       moveVec = distance.normalized;
       moveVec.y = 0.0f;

       agent.SetDestination(destination);

       Debug.Log(gameObject.name + ": Move");
   }

   private void Attack(Vector3 target)
   {
       if (!combat.IsAttacking && attackCooldown <= 0.0f)
       {
          // dude.Look(prey.transform.position - transform.position);
           bool successfulAttack = combat.OnAttack();
           if (successfulAttack)
           {
               lastAttackTime = Time.fixedTime;
               actualAttackRate = attackRate + (Random.value - 0.5f) * attackRateFluctuation;
           }
       }
   }

   private GameObject GetPlayer()
   {
       return Player.instance.gameObject;
   }

   private IEnumerator SummoningSickness()
   {
       this.OnDisable();
       yield return new WaitForSeconds(1.0f);
       this.OnEnable();
   }

   private float attackCooldown
   {
       get
       {
           return Mathf.Max(actualAttackRate - (Time.fixedTime - lastAttackTime), 0f);
       }
   }

   private void OnDrawGizmos()
   {
       if (avoidDistance != Vector3.zero && sqrDistance <= sqrDangerDistance)
       {
           var radius = avoider.GetComponent<SphereCollider>().radius;

           Gizmos.color = Color.blue;
           Gizmos.DrawWireSphere(transform.position, radius);
       }
   }*/
}
