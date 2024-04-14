
public class Player : LivingEntity
{
    public void ToggleStrafe()
    {
        ThirdPersonController.isStrafing = !ThirdPersonController.isStrafing;
    }
}