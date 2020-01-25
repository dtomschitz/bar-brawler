using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : EntityAnimator
{
    private NavMeshAgent navMeshAgent;

    protected override void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        base.Start();
    }

    void Update()
    {
        animator.SetFloat("speed", navMeshAgent.velocity.magnitude / navMeshAgent.speed, .1f, Time.deltaTime);
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}
