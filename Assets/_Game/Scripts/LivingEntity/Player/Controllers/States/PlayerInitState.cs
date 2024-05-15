using UnityEngine;

namespace CharacterPlayer
{
    public class PlayerInitState : PlayerStateBase
    {
        public PlayerInitState(LivingEntity livingEntity, bool needsExitTime = false, bool isGhostState = true) : base(livingEntity, needsExitTime, isGhostState)
        {
        }

        public override void Init()
        {
        }
    }
}