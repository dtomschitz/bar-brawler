using System;
using UnityEngine;
using Items;
using System.Collections;

/// <summary>
/// Class <c>EntityCombat</c> is the base class which handels combat relatet
/// stuff such as changing the combat state and so the behvaior of the entity or
/// updating the mana.
/// </summary>
public class EntityCombat : MonoBehaviour
{
    public CombatState State { get; protected set; }
    public float maxStunnedTime;

    [Header("Mana")]
    public const int maxMana = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public event Action OnManaUsed;
    public event Action OnManaAdded;

    public float CurrentMana { get; protected set; }

    private EntityStats stats;

    protected virtual void Start()
    {
        stats = GetComponent<EntityStats>();
        if (stats == null) throw new NullReferenceException("Entity stats paramter cannot be null");

        State = CombatState.Idle;
    }

    /// <summary>
    /// If the entity is currently not blocking this method will call the <see cref="AddMana(float)"/>
    /// method in order to fill up the mana.
    /// </summary>
    protected virtual void Update()
    {
        if (!IsBlocking)
        {
            AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
        }
    }

    /// <summary>
    /// Loads a preset configurationen for enemis.
    /// </summary>
    /// <param name="config">The combat config which should get loaded.</param>
    public void Init(EnemyCombatConfig config)
    {
        if (config != null)
        {
            if (config.manaRegenerationAmount >= 0f) manaRegenerationAmount = config.manaRegenerationAmount;
            if (config.manaRegenerationSpeed >= 0f) manaRegenerationSpeed = config.manaRegenerationSpeed;
        }
    }

    /// <summary>
    /// This method will update the entity stats of the attacked entity based on
    /// the current set damage.
    /// </summary>
    /// <param name="stats">The stats of the opponent to attack.</param>
    /// <param name="item">The item with which the entity attacked the other one.</param>
    public void Attack(EntityStats stats, Equipment item)
    {
        stats.Damage(this.stats.damage, item);
        //OnAttack?.Invoke();
    }

    /// <summary>
    /// This method adds a set ammount of mana to the entity and calls the
    /// <see cref="OnManaAdded"/> event.
    /// </summary>
    /// <param name="amount">The ammount of mana the entity received.</param>
    public void AddMana(float amount)
    {
        CurrentMana += amount;
        CurrentMana = Mathf.Clamp(CurrentMana, 0f, maxMana);
        OnManaAdded?.Invoke();
    }

    /// <summary>
    /// This method reduces a set ammount of mana from the entity and calls the
    /// <see cref="OnManaUsed"/> event.
    /// </summary>
    /// <param name="amount">The ammount of mana the entity lost.</param>
    public void UseMana(float amount = 1f)
    {
        //amount = Mathf.Clamp(amount, 0, float.MaxValue);
        CurrentMana -= amount;
        OnManaUsed?.Invoke();
    }

    /// <summary>
    /// Sets the new combat state based on the current equipped item.
    /// </summary>
    /// <param name="item">The currently equiped item.</param>
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

    /// <summary>
    /// Sets the new combat state but only if the combat state is a new one or
    /// the current game state is set to <see cref="GameStateType.InGame"/>. 
    /// </summary>
    /// <param name="newState">The new combat state.</param>
    public virtual void SetState(CombatState newState)
    {
        if (newState == State || !GameState.instance.IsInGame) return;
        State = newState; 

        /*if (newState == CombatState.Stunned)
        {
            StartCoroutine(StunnedRountine());
        }*/
    }

    /// <summary>
    /// This method calculates the normalized mana.
    /// </summary>
    /// <returns>The normalized mana.</returns>
    public float ManaNormalized
    {
        get { return CurrentMana / maxMana; }
    }

    /// <summary>
    /// This method checks whether the entity is currently attack or drinking.
    /// </summary>
    /// <returns>True if <see cref="IsAttacking"/> or <see cref="IsDrinking"/>
    /// returned true; otherwhise false.
    /// </returns>
    public bool IsInAction
    {
        get { return IsAttacking || IsDrinking; }
    }

    /// <summary>
    /// This method checks if the entity is currently attacking or not.
    /// </summary>
    /// <returns>True if the combat state is set to <see cref="CombatState.Fist_Attack"/>,
    /// <see cref="CombatState.Knife_Attack"/> or <see cref="CombatState.Revolver_Attack"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsAttacking
    {
        get { return State == CombatState.Fist_Attack || State == CombatState.Bottle_Attack || State == CombatState.Knife_Attack || State == CombatState.Revolver_Attack; }
    }

    /// <summary>
    /// This method checks if the entity is currently blocking attacks.
    /// </summary>
    /// <returns>True if the combat state is set to <see cref="CombatState.Fist_Block"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsBlocking
    {
        get { return State == CombatState.Fist_Block; }
    }

    /// <summary>
    /// This method checks if the entity is drinking or not.
    /// </summary>
    /// <returns>True if the combat state is set to <see cref="CombatState.Drinking"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsDrinking
    {
        get { return State == CombatState.Drinking; }
    }

    /// <summary>
    /// This method checks if the entity is stunned or not.
    /// </summary>
    /// <returns>True if the combat state is set to <see cref="CombatState.Stunned"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsStunned
    {
        get { return State == CombatState.Stunned; }
    }

    private IEnumerator StunnedRountine()
    {
        yield return new WaitForSeconds(maxStunnedTime);
        SetState(CombatState.Idle);
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
