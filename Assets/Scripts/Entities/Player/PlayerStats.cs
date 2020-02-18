using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Items;

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

    public void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem is Weapon)
        {
            damage = (newItem as Weapon).damage;
        }
    }

    public override void Damage(float damage, Equipment item = null)
    {
        base.Damage(damage, item);
        StopAllCoroutines();
        StartCoroutine(StartGamePadVibration(damage));
    }

    private IEnumerator StartGamePadVibration(float damage)
    {
        Gamepad.current.SetMotorSpeeds(damage / 100, damage / 100);
        yield return new WaitForSeconds(.5f);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}
