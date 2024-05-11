using UnityEngine;

namespace CharacterPlayer
{
    public class PlayerDeathState : PlayerStateBase
    {
        public PlayerDeathState(LivingEntity livingEntity, bool needsExitTime, bool isGhostState = false) : base(livingEntity, needsExitTime, isGhostState) { }

        public override void OnEnter() => player.Animator.CrossFade("Death", .15f);
    }
}