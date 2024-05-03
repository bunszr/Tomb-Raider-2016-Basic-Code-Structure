using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using WeaponNamescape.Enemy;

namespace EnemyNamescape.BHT
{
    public class AimPositionerAction : Action
    {
        [SerializeField] SharedTransform weaponModelTransform;
        [SerializeField] SharedGameObject enemyTarget;

        IAimTargetTransform _aimTargetTransform;
        IEnemyTarget _enemyTarget;

        public override void OnAwake()
        {
            _aimTargetTransform = weaponModelTransform.Value.transform.GetComponent<IAimTargetTransform>();
        }

        public override void OnStart()
        {
            _enemyTarget = enemyTarget.Value.transform.GetComponent<IEnemyTarget>();
        }

        public override void OnEnd() { }

        public override TaskStatus OnUpdate()
        {
            _aimTargetTransform.AimTargetTransform.position = _enemyTarget.BulletTargetLocation;
            return TaskStatus.Running;
        }
    }
}