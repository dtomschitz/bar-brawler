using Items;

public class PlayerAnimator : EntityAnimator
{
    protected override void Start()
    {
        base.Start();
        GetComponent<EquipmentManager>().OnItemEquipped += OnItemEquipped;
    }

    public void OnItemEquipped(Equipment newItem, Equipment oldItem) => SetEquipment(newItem);

    public override void Move(float forward, float strafe)
    {
        base.Move(forward, strafe);

        //TODO Sounds
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}