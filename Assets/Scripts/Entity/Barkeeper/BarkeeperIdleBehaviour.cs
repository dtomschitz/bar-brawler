using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkeeperIdleBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int idle = Random.Range(0, 3);
        animator.SetInteger("Idle", idle);
    }
}
