using UnityEngine;

[CreateAssetMenu(fileName = "New Combat Config", menuName = "Configs/Combat Config")]
public class EnemyCombatConfig : ScriptableObject
{
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;
}