using UnityEngine;
using Items;

public class EntityCombatBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player player = animator.GetComponentInParent<Player>();

        if (player != null && player.equipment.CurrentEquipment != null)
        {
            player.combat.SetState(player.equipment.CurrentEquipment);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player player = animator.GetComponentInParent<Player>();
        if (player != null)
        {
            player.combat.SetState(CombatState.Idle);

            Equipment item = player.equipment.CurrentEquipment;
            if (item != null && item.IsDrink) player.inventory.RemoveItem(item);
        }
    }
}
