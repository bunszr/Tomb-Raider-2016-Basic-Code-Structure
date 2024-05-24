using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class EnemyWeaponBaseInstaller : WeaponBaseInstaller, IWeapon
    {
        [SerializeField] protected LivingEntity livingEntity;
        [SerializeField] protected EnemyWeaponBase enemyWeaponBase;

        public Transform Transform => transform;

        public ReactiveProperty<bool> HasEquipRP { get; private set; } = new ReactiveProperty<bool>();

        protected virtual void Awake()
        {
            WeaponBase._Animator = livingEntity as IAnimator;
            enemyWeaponBase = WeaponBase as EnemyWeaponBase;

            enemyWeaponBase.WeaponData = new WeaponData(enemyWeaponBase.WeaponDataSaveable);
            enemyWeaponBase.NormalAmmo = new NormalAmmo(enemyWeaponBase.NormalAmmoSaveable);

            WeaponBase._AmmoDataRP = new ReactiveProperty<IAmmoData>(enemyWeaponBase.NormalAmmo);

            AddChecksToFire(new HasBulletInTheMagazineCheck(WeaponBase._AmmoDataRP));
            AddChecksToFire(new HasAimCheck(WeaponBase as IAimIsTaken));

            AddEquiptable(new WeaponReloadingEnemyFSM(WeaponBase));
        }

        protected virtual void Start() { }

        [Button]
        public virtual void Equip()
        {
            if (HasEquipRP.Value) Debug.LogError("The weapon already equiped", transform);
            _EquipableList.ForEach(x => x.Enter());
            HasEquipRP.Value = true;
        }

        [Button]
        public virtual void Unequip()
        {
            if (!HasEquipRP.Value) Debug.LogError("The weapon already unequip", transform);
            _EquipableList.ForEach(x => x.Exit());
            HasEquipRP.Value = false;
        }
    }
}