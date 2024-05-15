using Character;
using UnityEngine;

namespace CharacterPlayer
{
    public class PlayerDeathState : PlayerStateBase
    {
        GameObject playerControllerParentGo;

        public PlayerDeathState(LivingEntity livingEntity, GameObject playerControllerParentGo, bool needsExitTime, bool isGhostState = false) : base(livingEntity, needsExitTime, isGhostState)
        {
            this.playerControllerParentGo = playerControllerParentGo;
        }

        public override void OnEnter()
        {
            playerControllerParentGo.GetComponentsInChildren<PlayerController>().Foreach(x => x.Deactivate());
            player.ThirdPersonInputMonobehaviour.enabled = false;
            player.Rb.isKinematic = true;
            player.Colider.enabled = false;
            player.Animator.CrossFade("Death", .15f);
        }
    }
}