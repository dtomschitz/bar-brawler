using System;
using UnityEngine;
using Items;
using System.Collections;

public enum CombatState
{
    Idle,
    FistBlock,
    FistAttack,
    BottleAttack,
    KnifeAttack,
    RevolverAttack,
    Stunned,
    Drinking
}

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
    /// This method will update the entity stats of the attacked entity based on
    /// the current set damage.
    /// </summary>
    /// <param name="stats">The stats of the opponent to attack.</param>
    /// <param name="item">The item with which the entity attacked the other one.</param>
    public void Attack(EntityStats stats, Equipment item)
    {
        stats.Damage(this.stats.damage, item);
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
                newState = CombatState.FistAttack;
                break;
            case ItemType.Bottle:
                newState = CombatState.BottleAttack;
                break;
            case ItemType.Knife:
                newState = CombatState.KnifeAttack;
                break;
            case ItemType.Revolver:
                newState = CombatState.RevolverAttack;
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
    /// <returns>True if the combat state is set to <see cref="CombatState.FistAttack"/>,
    /// <see cref="CombatState.KnifeAttack"/> or <see cref="CombatState.RevolverAttack"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsAttacking
    {
        get { return State == CombatState.FistAttack || State == CombatState.BottleAttack || State == CombatState.KnifeAttack || State == CombatState.RevolverAttack; }
    }

    /// <summary>
    /// This method checks if the entity is currently blocking attacks.
    /// </summary>
    /// <returns>True if the combat state is set to <see cref="CombatState.FistBlock"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsBlocking
    {
        get { return State == CombatState.FistBlock; }
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
