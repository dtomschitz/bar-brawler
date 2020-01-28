using Items;

public class PlayerStats : EntityStats
{
    public float manaRegenerationSpeed;

    private PlayerEquipment equipment;

    public override void Start()
    {
        base.Start();
        equipment = GetComponent<PlayerEquipment>();
        equipment.OnItemEquipped += OnItemEquipped;
    }

    private void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem is Weapon)
        {
            damage = (newItem as Weapon).damage;
        }

        /*if (oldItem != null && oldItem is Weapon)
        {
            damage.RemoveModifier((oldItem as Weapon).damage);
        }*/
    }
}
