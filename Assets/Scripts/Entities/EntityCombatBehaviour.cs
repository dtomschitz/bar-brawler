using UnityEngine;

public class EntityCombatBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.instance.combat.SetState(CombatState.ATTACKING);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.instance.combat.SetState(CombatState.IDLE);
    }
}
