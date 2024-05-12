using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Invector.vCharacterController
{
    public class vThirdPersonInputForAI : vThirdPersonInputBase
    {
        public virtual void OnAnimatorMove()
        {
            thirdPersonController.ControlAnimatorRootMotion(); // handle root motion animations 
        }

        protected virtual bool JumpConditions()
        {
            return thirdPersonController.isGrounded && thirdPersonController.GroundAngle() < thirdPersonController.slopeLimit && !thirdPersonController.isJumping && !thirdPersonController.stopMove;
        }

    }
}