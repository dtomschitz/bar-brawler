/// <summary>
/// Class <c>PlayerAnimator</c> extends the <c>EntityAnimator</c> class an
/// overrides some of the base methods in order to handle player specific stuff.
/// </summary>
public class PlayerAnimator : EntityAnimator
{
    /// <summary>
    /// This method overrides the base method of the <c>EntityAnimator</c> class
    /// and triggers the movement animation for the player. Additionally the
    /// move sound gets played back.
    /// </summary>
    /// <param name="forward">The forward velocity</param>
    /// <param name="strafe">The strafe velocity</param>
    public override void Move(float forward, float strafe)
    {
        base.Move(forward, strafe);
    }
}