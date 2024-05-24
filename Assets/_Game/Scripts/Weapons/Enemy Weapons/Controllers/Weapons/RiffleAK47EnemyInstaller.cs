using System.Collections.Generic;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class RiffleAK47EnemyInstaller : EnemyWeaponBaseInstaller
    {
        [SerializeField] RiffleAK47Enemy riffleAK47Enemy;

        protected override void Awake()
        {
            base.Awake();
            riffleAK47Enemy = WeaponBase as RiffleAK47Enemy;

            AddExtraFire(new FireAnimationBehaviour(livingEntity.Animator, WeaponBase.WeaponAnimationData.fireAnimName));
            AddExtraFire(new NormalBulletBehaviour(riffleAK47Enemy, riffleAK47Enemy.normalBulletModeData));

            AddEquiptable(new EnemyFireBehavior(WeaponBase, enemyWeaponBase.WeaponData, _ExtraFireList, _ChecksToFire));
            AddEquiptable(new EnemyAimBoolSetterBehavior(WeaponBase));
            AddEquiptable(new EnemyAimBehavior(WeaponBase, livingEntity, riffleAK47Enemy.enemyAimBehaviorData));
            AddEquiptable(new EnemyEquipBehaviour(livingEntity.Animator, WeaponBase.DrawWeaponInputInt));
        }
    }
}
