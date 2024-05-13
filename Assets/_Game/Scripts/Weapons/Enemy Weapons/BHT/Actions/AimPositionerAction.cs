using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class AimPositionerAction : Action
    {
        [SerializeField] SharedTransform aimTargetSH;

        public override TaskStatus OnUpdate()
        {
            aimTargetSH.Value.position = EnemyManager.Ins.player.BulletTargetLocation;
            return TaskStatus.Running;
        }
    }
}