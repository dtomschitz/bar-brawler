using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : EntityAnimator
{
    private NavMeshAgent navMeshAgent;

    protected override void Start()
    {
        base.Start();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float forward = Vector3.Dot(navMeshAgent.velocity.normalized, gameObject.transform.forward);
        SetForward(forward);
    }
}
