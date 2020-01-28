using UnityEngine;

[CreateAssetMenu(fileName = "New Combat Config", menuName = "Configs/Combat Config")]
public class CombatConfig : ScriptableObject
{
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;
}