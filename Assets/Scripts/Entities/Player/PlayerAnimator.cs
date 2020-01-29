public class PlayerAnimator : EntityAnimator
{
    protected override void Start()
    {
        base.Start();
    }

    public override void Move(float forward, float strafe)
    {
        base.Move(forward, strafe);

        //TODO Sounds
    }
}