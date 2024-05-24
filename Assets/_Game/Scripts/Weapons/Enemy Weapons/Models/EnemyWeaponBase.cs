using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class EnemyWeaponBase : WeaponBase, IAimIsTaken, IAimTargetTransform
    {
        [SerializeField] WeaponDataSaveable weaponDataSaveable;
        [SerializeField] NormalAmmoSaveable normalAmmoSaveable;

        [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
        [ReadOnly, ShowInInspector] public NormalAmmo NormalAmmo { get; set; }

        public NormalBulletBehaviour.NormalBulletBehaviourData normalBulletModeData;
        public EnemyAimBehavior.EnemyAimBehaviorData enemyAimBehaviorData;
        public ReactiveProperty<bool> HasAimed { get; set; } = new ReactiveProperty<bool>();

        public Transform AimTargetTransform => enemyAimBehaviorData.aimTargetTransform;

        public WeaponDataSaveable WeaponDataSaveable { get => weaponDataSaveable; }
        public NormalAmmoSaveable NormalAmmoSaveable { get => normalAmmoSaveable; }
    }
}