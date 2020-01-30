using Items;

public class PlayerStats : EntityStats
{
    private PlayerEquipment equipment;
    public override void Start()
    {
        base.Start();

        CurrentHealth = maxHealth;

        equipment = GetComponent<PlayerEquipment>();
        equipment.OnItemEquipped += OnItemEquipped;
    }

    private void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem is Weapon)
        {
            damage = (newItem as Weapon).damage;
        }
    }
}
