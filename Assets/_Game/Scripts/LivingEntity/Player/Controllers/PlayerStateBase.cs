namespace CharacterPlayer
{
    public abstract class PlayerStateBase : LivingStateBase
    {
        protected Player player;

        protected PlayerStateBase(LivingEntity livingEntity, bool needsExitTime, bool isGhostState = false) : base(livingEntity, needsExitTime, isGhostState)
        {
            player = living as Player;
        }
    }
}