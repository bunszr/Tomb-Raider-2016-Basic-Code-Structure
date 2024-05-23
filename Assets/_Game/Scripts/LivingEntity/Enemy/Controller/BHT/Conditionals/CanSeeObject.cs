using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Tutorials
{
    // You can get that script from youtube video description https://www.youtube.com/watch?v=PuLuwzgYB4g&list=PLCPL5IYZm1NLVVxJx3-CFTLuHvLbCgmzk&index=2 

    [TaskCategory("Tutorial")]
    [TaskIcon("Assets/Behavior Designer Tutorials/Tasks/Editor/{SkinColor}CanSeeObjectIcon.png")]
    public class CanSeeObject : Conditional
    {
        [Tooltip("The object that we are searching for")]
        public SharedGameObject targetObject;
        [Tooltip("The field of view angle of the agent (in degrees)")]
        public SharedFloat fieldOfViewAngle = 90;
        [Tooltip("The distance that the agent can see")]
        public SharedFloat viewDistance = 1000;
        [Tooltip("The object that is within sight")]
        public SharedGameObject returnedObject;

        /// <summary>
        /// Returns success if an object was found otherwise failure
        /// </summary>
        /// <returns></returns>
        public override TaskStatus OnUpdate()
        {
            returnedObject.Value = WithinSight(targetObject.Value, fieldOfViewAngle.Value, viewDistance.Value);
            if (returnedObject.Value != null)
            {
                // Return success if an object was found
                return TaskStatus.Success;
            }
            // An object is not within sight so return failure
            return TaskStatus.Failure;
        }

        /// <summary>
        /// Determines if the targetObject is within sight of the transform.
        /// </summary>
        private GameObject WithinSight(GameObject targetObject, float fieldOfViewAngle, float viewDistance)
        {
            if (targetObject == null)
            {
                return null;
            }

            var direction = targetObject.transform.position - transform.position;
            direction.y = 0;
            var angle = Vector3.Angle(direction, transform.forward);
            if (direction.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f)
            {
                // The hit agent needs to be within view of the current agent
                if (LineOfSight(targetObject))
                {
                    return targetObject; // return the target object meaning it is within sight
                }
            }
            return null;
        }

        /// <summary>
        /// Returns true if the target object is within the line of sight.
        /// </summary>
        private bool LineOfSight(GameObject targetObject)
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, targetObject.transform.position, out hit))
            {
                if (hit.transform.IsChildOf(targetObject.transform) || targetObject.transform.IsChildOf(hit.transform))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Draws the line of sight representation
        /// </summary>
        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}