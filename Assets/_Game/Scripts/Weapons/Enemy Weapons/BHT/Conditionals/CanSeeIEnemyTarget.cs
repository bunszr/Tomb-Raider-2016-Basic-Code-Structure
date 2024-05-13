using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using WeaponNamescape.Enemy;

namespace EnemyNamescape.BHT
{
    public class CanSeeIEnemyTarget : Conditional
    {
        [SerializeField] SharedFloat fieldOfViewAngle = 90;
        [SerializeField] SharedFloat viewDistance = 1000;
        [SerializeField] SharedGameObject thirdPersonControllerGo;

        public override TaskStatus OnUpdate()
        {
            return WithinSight(fieldOfViewAngle.Value, viewDistance.Value) ? TaskStatus.Success : TaskStatus.Failure;
        }

        private GameObject WithinSight(float fieldOfViewAngle, float viewDistance)
        {
            var direction = EnemyManager.Ins.player.transform.position - thirdPersonControllerGo.Value.transform.position;
            direction.y = 0;
            var angle = Vector3.Angle(direction, thirdPersonControllerGo.Value.transform.forward);
            if (direction.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Linecast(thirdPersonControllerGo.Value.transform.position + EnemyStaticData.RaycastUpVector, EnemyManager.Ins.player.BulletTargetLocation, out hit))
                {
                    if (EnemyManager.Ins.player.transform == hit.transform) return EnemyManager.Ins.player.gameObject;
                }
            }
            return null;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * thirdPersonControllerGo.Value.transform.forward;
            UnityEditor.Handles.DrawSolidArc(thirdPersonControllerGo.Value.transform.position, thirdPersonControllerGo.Value.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}