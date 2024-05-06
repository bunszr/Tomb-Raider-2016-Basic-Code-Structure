﻿using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using WeaponNamescape.Enemy;

namespace EnemyNamescape.BHT
{
    public class CanSeeIEnemyTarget : Conditional
    {
        public SharedFloat fieldOfViewAngle = 90;
        public SharedFloat viewDistance = 1000;
        public SharedGameObject returnedObject;
        public SharedTransform charaterControllerTransform;

        public override TaskStatus OnUpdate()
        {
            returnedObject.Value = WithinSight(fieldOfViewAngle.Value, viewDistance.Value);
            if (returnedObject.Value != null)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

        private GameObject WithinSight(float fieldOfViewAngle, float viewDistance)
        {
            for (int i = 0; i < StaticColliderManager.EnemyTargetList.Count; i++)
            {
                Transform targetT = StaticColliderManager.EnemyTargetList[i].EnemyTargetTransform;
                var direction = targetT.position - charaterControllerTransform.Value.position;
                direction.y = 0;
                var angle = Vector3.Angle(direction, charaterControllerTransform.Value.forward);
                if (direction.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f)
                {
                    if (LineOfSight(targetT.gameObject))
                    {
                        return targetT.gameObject;
                    }
                }
            }
            return null;
        }

        private bool LineOfSight(GameObject targetObject)
        {
            RaycastHit hit;
            if (Physics.Linecast(charaterControllerTransform.Value.position + Vector3.up, targetObject.transform.position, out hit))
            {
                if (StaticColliderManager._EnemyTargetDictionary.TryGetValue(hit.transform.GetInstanceID(), out IEnemyTarget _enemyTarget)) return true;
            }
            return false;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * charaterControllerTransform.Value.forward;
            UnityEditor.Handles.DrawSolidArc(charaterControllerTransform.Value.position, charaterControllerTransform.Value.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}