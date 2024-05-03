using System.Collections.Generic;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class PistolEnemyInstaller : EnemyWeaponBaseInstaller
    {
        [SerializeField] LivingEntity livingEntity;
        [SerializeField] PistolEnemy pistolEnemy;

        [SerializeField] Transform weaponHolder;
        [SerializeField] Transform weaponHolderUnderHand;

        protected override void Awake()
        {
            base.Awake();
            pistolEnemy = weaponBase as PistolEnemy;

            weaponHolder.transform.parent = weaponHolderUnderHand;
            weaponHolder.transform.localPosition = Vector3.zero;
            weaponHolder.transform.localRotation = Quaternion.identity;

            _extraFireList = new List<IExtraFire>()
            {
                new FireAnimationBehaviour(livingEntity.Animator),
                new NormalBulletBehaviour(pistolEnemy, pistolEnemy.normalBulletModeData),
            };

            _equipableList = new List<IEquiptable>()
            {
                new EnemyFireBehavior(weaponBase, _extraFireList, _checksToFire),
                new EnemyAimBoolSetterBehavior(weaponBase),
                new EnemyAimBehavior(weaponBase, livingEntity, pistolEnemy.enemyAimBehaviorData),
            };

            livingEntity.Animator.SetInteger(APs.DrawWeaponInt, 0); // Fix Later - Add DrawWeaponInt to WeaponDataScriptable
            livingEntity.Animator.SetTrigger(APs.DrawWeaponTrigger);
        }
    }
}
