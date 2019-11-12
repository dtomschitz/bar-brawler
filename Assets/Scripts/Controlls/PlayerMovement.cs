using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<PlayerController>().onFocusChanged += OnFocusChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Move(target.position);
            //FaceTarget();
        }
    }

    public void Move(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void OnFocusChanged(Interactable interactable)
    {
        if (interactable != null)
        {
            agent.stoppingDistance = interactable.radius * .8f;
            agent.updateRotation = false;

            target = interactable.interaction;
        } else
        {
            agent.stoppingDistance = 0f;
            agent.updateRotation = true;
            target = null;
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.1f);
    }
}
