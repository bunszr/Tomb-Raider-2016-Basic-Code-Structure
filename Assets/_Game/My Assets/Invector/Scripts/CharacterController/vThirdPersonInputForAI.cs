using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Invector.vCharacterController
{
    public class vThirdPersonInputForAI : MonoBehaviour
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








// using Sirenix.OdinInspector;
// using UnityEngine;
// using UnityEngine.AI;

// namespace Invector.vCharacterController
// {
//     public class vThirdPersonInput : MonoBehaviour
//     {
//         #region Variables       

//         [Header("Controller Input")]
//         public string horizontalInput = "Horizontal";
//         public string verticallInput = "Vertical";
//         public KeyCode jumpInput = KeyCode.Space;
//         public KeyCode strafeInput = KeyCode.Tab; //Strafing is the act of moving sideways in a video game relative to the player's forward direction
//         public KeyCode sprintInput = KeyCode.LeftShift;

//         [Header("Camera Input")]
//         public string rotateCameraXInput = "Mouse X";
//         public string rotateCameraYInput = "Mouse Y";

//         [HideInInspector] public vThirdPersonController thirdPersonController;
//         [HideInInspector] public vThirdPersonCamera tpCamera;
//         [HideInInspector] public Camera cameraMain;

//         #endregion

//         #region Bünyamin
//         public Transform sezer_MoveDirectionT;
//         #endregion

//         protected virtual void Start()
//         {
//             InitilizeController();
//             InitializeTpCamera();
//         }

//         protected virtual void FixedUpdate()
//         {
//             thirdPersonController.UpdateMotor();               // updates the ThirdPersonMotor methods
//             thirdPersonController.ControlLocomotionType();     // handle the controller locomotion type and movespeed
//             thirdPersonController.ControlRotationType();       // handle the controller rotation type
//         }

//         protected virtual void Update()
//         {
//             InputHandle();                  // update the input methods
//             thirdPersonController.UpdateAnimator();            // updates the Animator Parameters
//         }

//         public virtual void OnAnimatorMove()
//         {
//             // if (cc == null) cc = GetComponent<vThirdPersonController>();

//             // cc.ControlAnimatorRootMotion(); // handle root motion animations 
//         }

//         #region Basic Locomotion Inputs

//         protected virtual void InitilizeController()
//         {
//             thirdPersonController = GetComponent<vThirdPersonController>();

//             if (thirdPersonController != null)
//                 thirdPersonController.Init();
//         }

//         protected virtual void InitializeTpCamera()
//         {
//             if (tpCamera == null)
//             {
//                 tpCamera = FindObjectOfType<vThirdPersonCamera>();
//                 if (tpCamera == null)
//                     return;
//                 if (tpCamera)
//                 {
//                     tpCamera.SetMainTarget(this.transform);
//                     tpCamera.Init();
//                 }
//             }
//         }

//         protected virtual void InputHandle()
//         {
//             MoveInput();
//             CameraInput();
//             // SprintInput();
//             StrafeInput();
//             // JumpInput();
//         }

//         public virtual void MoveInput()
//         {
//             // cc.input.x = Input.GetAxis(horizontalInput);
//             // cc.input.z = Input.GetAxis(verticallInput);
//         }


//         protected virtual void CameraInput()
//         {
//             if (!cameraMain)
//             {
//                 if (!Camera.main) Debug.Log("Missing a Camera with the tag MainCamera, please add one.");
//                 else
//                 {
//                     cameraMain = Camera.main;

//                     #region Bünyamin SEZER Bünyamin SEZER Bünyamin SEZER Bünyamin SEZER Bünyamin SEZER Bünyamin SEZER 
//                     // cc.rotateTarget = cameraMain.transform;
//                     // if (sezer_MoveDirectionT == null) Debug.LogError("sezer_MoveDirectionT is null");
//                     thirdPersonController.rotateTarget = sezer_MoveDirectionT;
//                     // cc.rotateTarget = GameManager.Ins.transform;
//                     #endregion
//                 }
//             }

//             if (cameraMain)
//             {
//                 thirdPersonController.UpdateMoveDirection(sezer_MoveDirectionT);
//             }

//             if (tpCamera == null)
//                 return;

//             var Y = Input.GetAxis(rotateCameraYInput);
//             var X = Input.GetAxis(rotateCameraXInput);

//             tpCamera.RotateCamera(X, Y);
//         }

//         protected virtual void StrafeInput()
//         {
//             if (Input.GetKeyDown(strafeInput))
//                 thirdPersonController.Strafe();
//         }

//         protected virtual void SprintInput()
//         {
//             if (Input.GetKeyDown(sprintInput))
//                 thirdPersonController.Sprint(true);
//             else if (Input.GetKeyUp(sprintInput))
//                 thirdPersonController.Sprint(false);
//         }

//         /// <summary>
//         /// Conditions to trigger the Jump animation & behavior
//         /// </summary>
//         /// <returns></returns>
//         protected virtual bool JumpConditions()
//         {
//             return thirdPersonController.isGrounded && thirdPersonController.GroundAngle() < thirdPersonController.slopeLimit && !thirdPersonController.isJumping && !thirdPersonController.stopMove;
//         }

//         /// <summary>
//         /// Input to trigger the Jump 
//         /// </summary>
//         protected virtual void JumpInput()
//         {
//             if (Input.GetKeyDown(jumpInput) && JumpConditions())
//                 thirdPersonController.Jump();
//         }

//         #endregion
//     }
// }