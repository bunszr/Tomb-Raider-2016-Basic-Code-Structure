using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Invector.vCharacterController
{
    public class vThirdPersonInput : vThirdPersonInputBase
    {
        public KeyCode jumpInput = KeyCode.Space;
        public KeyCode strafeInput = KeyCode.Tab; //Strafing is the act of moving sideways in a video game relative to the player's forward direction
        public KeyCode sprintInput = KeyCode.LeftShift;
        public string horizontalInput = "Horizontal";
        public string verticallInput = "Vertical";
        public CinemachineFreeLook freeLookCam;

        protected override void Update()
        {
            base.Update();
            MoveInput();
            RotationInput();
            SprintInput();
            JumpInput();
            StrafeInput();
        }

        void RotationInput()
        {
            // strafeDirectionT.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis(horizontalInput) * Time.deltaTime * strafeTurnSpeed, Vector3.up);
        }

        // public virtual void OnAnimatorMove()
        // {
        //     if (cc == null) cc = GetComponent<vThirdPersonController>();
        //     cc.ControlAnimatorRootMotion(); // handle root motion animations 
        // }

        public virtual void MoveInput()
        {
            Vector3 worldInput = new Vector3(Input.GetAxis(horizontalInput), 0, Input.GetAxis(verticallInput));
            float angle = Utility.FindDegree(transform.position - freeLookCam.transform.position, Utility.DegreeSpace.xz);
            Vector3 relativeCamInput = Quaternion.AngleAxis(freeLookCam.m_XAxis.Value, Vector3.up) * worldInput;


            Debug.DrawRay(freeLookCam.transform.position, relativeCamInput, Color.red);
            Debug.DrawRay(freeLookCam.transform.position, worldInput);

            thirdPersonController.input.x = relativeCamInput.x;
            thirdPersonController.input.z = relativeCamInput.z;

            // thirdPersonController.input.x = Input.GetAxis(horizontalInput);
            // thirdPersonController.input.z = Input.GetAxis(verticallInput);
        }

        protected virtual void StrafeInput()
        {
            if (Input.GetKeyDown(strafeInput)) thirdPersonController.Strafe();
        }

        public void StrafeOn()
        {
            if (Input.GetKeyDown(strafeInput)) thirdPersonController.Strafe();
        }

        protected virtual void SprintInput()
        {
            if (Input.GetKeyDown(sprintInput)) thirdPersonController.Sprint(true);
            else if (Input.GetKeyUp(sprintInput)) thirdPersonController.Sprint(false);
        }

        protected virtual bool JumpConditions()
        {
            return thirdPersonController.isGrounded && thirdPersonController.GroundAngle() < thirdPersonController.slopeLimit && !thirdPersonController.isJumping && !thirdPersonController.stopMove;
        }

        protected virtual void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput) && JumpConditions())
                thirdPersonController.Jump();
        }
    }
}