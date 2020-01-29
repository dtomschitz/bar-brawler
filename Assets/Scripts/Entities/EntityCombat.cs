using System;
using UnityEngine;
using Items;

public class EntityCombat : MonoBehaviour
{
    public CombatState state { get; protected set; }

    [Header("Mana")]
    public const int maxMana = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public event Action OnManaUsed;

    public float CurrentMana { get; protected set; }

    private EntityStats stats;

    protected virtual void Start()
    {
        stats = GetComponent<EntityStats>();
        state = CombatState.Idle;
    }

    protected virtual void Update()
    {
        //if(!IsBlocking) AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
    }

    public void Init(CombatConfig config)
    {
        if (config != null)
        {
            if (config.manaRegenerationAmount >= 0f) manaRegenerationAmount = config.manaRegenerationAmount;
            if (config.manaRegenerationSpeed >= 0f) manaRegenerationSpeed = config.manaRegenerationSpeed;
        }
    }

    public void Attack(EntityStats stats, Equipment item)
    {
        stats.Damage(this.stats.damage, item);
        //OnAttack?.Invoke();
    }

    public void AddMana(float amount)
    {
        CurrentMana += amount;
        CurrentMana = Mathf.Clamp(CurrentMana, 0f, maxMana);
    }

    public void UseMana(float amount = 1f)
    {
        //amount = Mathf.Clamp(amount, 0, float.MaxValue);
        CurrentMana -= amount;
        OnManaUsed?.Invoke();
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

    public float ManaNormalized
    {
        get { return CurrentMana / maxMana; }
    }

    public bool IsInAction
    {
        get { return IsAttacking || IsDrinking; }
    }

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
