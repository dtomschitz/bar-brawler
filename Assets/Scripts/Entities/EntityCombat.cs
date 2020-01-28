using System;
using UnityEngine;
using Items;
using Utils;

public class EntityCombat : MonoBehaviour
{
    public event Action OnAttack;
    public CombatState state { get; protected set; }

    [Header("Mana")]
    public const int MAX_MANA = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public float CurrentMana { get; protected set; }
    public bool IsUsingMana { get; set; }

    private EntityStats stats;

    protected virtual void Start()
    {
        stats = GetComponent<EntityStats>();
        state = CombatState.Idle;
    }

    protected virtual void Update()
    {
        if (!IsUsingMana) AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
    }

    /*public virtual bool OnAttack()
    {
        //StartCoroutine(DoDamge(stats, .15f));
        //OnAttack?.Invoke();
        return false;
    }
    */

    public void Attack(EntityStats stats)
    {
        //StartCoroutine(DoDamge(stats, .15f));
        stats.Damage(this.stats.damage);
        OnAttack?.Invoke();
    }

    public void AddMana(float amount)
    {
        CurrentMana += amount;
        CurrentMana = Mathf.Clamp(CurrentMana, 0f, MAX_MANA);
    }

    public void UseMana(float amount = 1f)
    {
        amount = Mathf.Clamp(amount, 0, float.MaxValue);

        if (amount == 1f)
        {
            CurrentMana -= amount;
        }
        else
        {
            FunctionUpdater.Create(() =>
            {
                CurrentMana = Mathf.Lerp(CurrentMana, CurrentMana - amount, Time.deltaTime * 1f);
            });
        }
    }

    public void SetState(Equipment item)
    {
        CombatState newState;
        switch (item.type)
        {
            case ItemType.Fist:
                newState = CombatState.Fist_Attack;
                break;
            case ItemType.Bottle:
                newState = CombatState.Bottle_Attack;
                break;
            case ItemType.Knife:
                newState = CombatState.Knife_Attack;
                break;
            case ItemType.Revolver:
                newState = CombatState.Revolver_Attack;
                break;
            case ItemType.Whiskey:
            case ItemType.Beer:
            case ItemType.Feuersaft:
                newState = CombatState.Drinking;
                break;
            default:
                newState = CombatState.Idle;
                break;
        }

        SetState(newState);
    }

    public virtual void SetState(CombatState newState)
    {
        if (newState == state || !GameState.instance.IsInGame) return;
        state = newState; 
    }

    /*IEnumerator DoDamge(EntityStats stats, float delay)
    {
        stats.Damage(entityStats.damage);
        yield return new WaitForSeconds(delay);
    }*/

    public bool IsAttacking
    {
        get { return state == CombatState.Fist_Attack || state == CombatState.Bottle_Attack || state == CombatState.Knife_Attack || state == CombatState.Revolver_Attack; }
    }

    public bool IsBlocking
    {
        get { return state == CombatState.Fist_Block; }
    }

    public bool IsDrinking
    {
        get { return state == CombatState.Drinking; }
    }

    public bool IsStunned
    {
        get { return state == CombatState.Stunned; }
    }
}

public enum CombatState
{
    Idle,
    Fist_Block,
    Fist_Attack,
    Bottle_Attack,
    Knife_Attack,
    Revolver_Attack,
    Stunned,
    Drinking
}
