using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace Weapon
{
    public class SingleShotCondition : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            return Input.GetMouseButtonDown(0) ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}