using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class EnemyWeaponBase : WeaponBase, IAimIsTaken, IAimTargetTransform
    {
        public NormalBulletBehaviour.NormalBulletBehaviourData normalBulletModeData;
        public EnemyAimBehavior.EnemyAimBehaviorData enemyAimBehaviorData;
        public ReactiveProperty<bool> HasAimed { get; set; } = new ReactiveProperty<bool>();

        public Transform AimTargetTransform => enemyAimBehaviorData.aimTargetTransform;
    }
}