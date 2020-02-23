using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Items;

/// <summary>
/// Class <c>PlayerStats</c> extends the <c>EntityStats</c> class and override
/// specifc methods. Additionally new methods are implemented in order to update
/// the damage the player can deal if he equipped an new item.
/// </summary>
public class PlayerStats : EntityStats
{
    private PlayerEquipment equipment;
    protected override void Start()
    {
        base.Start();

        CurrentHealth = maxHealth;

        equipment = GetComponent<PlayerEquipment>();
        equipment.OnItemEquipped += OnItemEquipped;
    }

    /// <summary>
    /// This method gets called if the player equipped an new item.  If the item
    /// is not equals to the current equipped item and is of the type <see cref="Weapon"/>
    /// the new damage will be override the old one.
    /// </summary>
    /// <param name="newItem">The new equipped item.</param>
    /// <param name="oldItem">The old equipped item.</param>
    public void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem is Weapon)
        {
            damage = (newItem as Weapon).damage;
        }
    }

    /// <summary>
    /// This method overrides the base <see cref="base.Damage(float, Equipment)"/>
    /// method. In order to give the user additional feedback beside the visual
    /// and auditiv the gamepad will start vibrating <see cref="StartGamePadVibration(float)"/>
    /// for a set amount of time. The intensity of the vibrations depends on the
    /// size of the received damage.
    /// </summary>
    /// <param name="damage">The damage which the entity took.</param>
    /// <param name="item">The item with which the damage where dealed.</param>
    public override void Damage(float damage, Equipment item = null)
    {
        base.Damage(damage, item);
        StopAllCoroutines();
        StartCoroutine(StartGamePadVibration(damage));
    }

    /// <summary>
    /// This methods starts the vibrations of the gamepad based on the given
    /// amount of damage.
    /// </summary>
    /// <param name="damage">The amount damage which the player received.</param>
    /// <returns></returns>
    private IEnumerator StartGamePadVibration(float damage)
    {
        Gamepad.current.SetMotorSpeeds(damage / 100, damage / 100);
        yield return new WaitForSeconds(.5f);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}