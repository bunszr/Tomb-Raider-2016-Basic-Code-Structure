using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using WeaponNamescape.Enemy;

namespace EnemyNamescape.BHT
{
    public class ToggleStrafeWithEnemyTargetDistance : Action
    {
        IThirdPersonController _thirdPersonController;

        [SerializeField] float maxDstThresholdToStrafeTrue = 8;

        public override void OnAwake()
        {
            _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();
        }

        public override void OnStart()
        {
            float distanceToEnemyTarget = Vector3.Distance(_thirdPersonController.Transform.position, EnemyManager.Ins.player.transform.position);
            if (distanceToEnemyTarget < maxDstThresholdToStrafeTrue)
            {
                if (!_thirdPersonController.IsStrafe) _thirdPersonController.IsStrafe = true;
            }
            else
            {
                if (_thirdPersonController.IsStrafe) _thirdPersonController.IsStrafe = false;
            }
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (EnemyManager.Ins != null && EnemyManager.Ins.player != null)
            {
                var oldColor = UnityEditor.Handles.color;
                var color = Color.yellow;
                color.a = 0.1f;
                UnityEditor.Handles.color = color;
                UnityEditor.Handles.DrawSolidDisc(EnemyManager.Ins.player.transform.position, Vector3.up, maxDstThresholdToStrafeTrue);
                UnityEditor.Handles.color = oldColor;
            }
#endif
        }
    }
}