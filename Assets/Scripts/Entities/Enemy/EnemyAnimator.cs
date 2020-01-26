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

        float forward = Vector3.Dot(navMeshAgent.velocity.normalized, gameObject.transform.forward);
        //float strafe = Vector3.Dot(navMeshAgent.destination, transform.right);

        SetForward(forward);
        //SetForward(strafe);
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}
