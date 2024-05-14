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

            AddExtraFire(new FireAnimationBehaviour(livingEntity.Animator, WeaponBase.WeaponDataScriptable.weaponAnimationData.fireAnimName));
            AddExtraFire(new NormalBulletBehaviour(riffleAK47Enemy, riffleAK47Enemy.normalBulletModeData));

            AddEquiptable(new EnemyFireBehavior(WeaponBase, _ExtraFireList, _checksToFire));
            AddEquiptable(new EnemyAimBoolSetterBehavior(WeaponBase));
            AddEquiptable(new EnemyAimBehavior(WeaponBase, livingEntity, riffleAK47Enemy.enemyAimBehaviorData));

            livingEntity.Animator.SetInteger(APs.DrawWeaponInt, 1); // Fix Later - Add DrawWeaponInt to WeaponDataScriptable
            livingEntity.Animator.SetTrigger(APs.DrawWeaponTrigger);
        }
    }
}
