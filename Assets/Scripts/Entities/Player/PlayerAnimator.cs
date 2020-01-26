using Items;

public class PlayerAnimator : EntityAnimator
{
    protected override void Start()
    {
        base.Start();
        GetComponent<EquipmentManager>().OnItemEquipped += OnItemEquipped;
    }

    public void OnItemEquipped(Equipment newItem, Equipment oldItem) => SetEquipment(newItem);

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}