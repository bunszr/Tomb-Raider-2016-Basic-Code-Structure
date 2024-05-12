using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Invector.vCharacterController
{
    public abstract class vThirdPersonInputBase : MonoBehaviour
    {
        [ReadOnly, ShowInInspector] public vThirdPersonController thirdPersonController;

        public float strafeTurnSpeed = .05f;
        public Transform strafeDirectionT;

        protected virtual void Start()
        {
            thirdPersonController = GetComponent<vThirdPersonController>();
            if (thirdPersonController != null) thirdPersonController.Init();
            thirdPersonController.rotateTarget = strafeDirectionT;
        }

        protected virtual void Update()
        {
            thirdPersonController.UpdateMoveDirection(strafeDirectionT);
            thirdPersonController.UpdateAnimator();            // updates the Animator Parameters
        }

        protected virtual void FixedUpdate()
        {
            thirdPersonController.UpdateMotor();               // updates the ThirdPersonMotor methods
            thirdPersonController.ControlLocomotionType();     // handle the controller locomotion type and movespeed
            thirdPersonController.ControlRotationType();       // handle the controller rotation type
        }
    }
}