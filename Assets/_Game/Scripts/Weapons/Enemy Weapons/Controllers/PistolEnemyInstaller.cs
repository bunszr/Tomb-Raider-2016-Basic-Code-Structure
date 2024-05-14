using System.Collections.Generic;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class PistolEnemyInstaller : EnemyWeaponBaseInstaller
    {
        [SerializeField] PistolEnemy pistolEnemy;

        protected override void Awake()
        {
            base.Awake();
            pistolEnemy = WeaponBase as PistolEnemy;

            AddExtraFire(new FireAnimationBehaviour(livingEntity.Animator, WeaponBase.WeaponDataScriptable.weaponAnimationData.fireAnimName));
            AddExtraFire(new NormalBulletBehaviour(pistolEnemy, pistolEnemy.normalBulletModeData));

            AddEquiptable(new EnemyFireBehavior(WeaponBase, _ExtraFireList, _checksToFire));
            AddEquiptable(new EnemyAimBoolSetterBehavior(WeaponBase));
            AddEquiptable(new EnemyAimBehavior(WeaponBase, livingEntity, pistolEnemy.enemyAimBehaviorData));

            livingEntity.Animator.SetInteger(APs.DrawWeaponInt, 0); // Fix Later - Add DrawWeaponInt to WeaponDataScriptable
            livingEntity.Animator.SetTrigger(APs.DrawWeaponTrigger);
        }
    }
}
