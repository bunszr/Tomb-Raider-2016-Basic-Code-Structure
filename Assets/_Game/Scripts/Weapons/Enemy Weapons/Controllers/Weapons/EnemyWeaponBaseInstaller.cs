using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class EnemyWeaponBaseInstaller : WeaponBaseInstaller, IWeapon
    {
        [SerializeField] protected LivingEntity livingEntity;

        public Transform Transform => transform;
        protected List<ICheck> _checksToFire;

        public ReactiveProperty<bool> HasEquipRP { get; private set; } = new ReactiveProperty<bool>();

        protected virtual void Awake()
        {
            WeaponBase.WeaponDataScriptable = WeaponBase.WeaponDataScriptable.CreateInstance();
            WeaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(WeaponBase.WeaponDataScriptable.NormalAmmo);
            _checksToFire = new List<ICheck>()
            {
                new HasBulletInTheMagazineCheck(WeaponBase),
                new HasAimCheck(WeaponBase as IAimIsTaken),
            };

            WeaponBase._ThirdPersonController = livingEntity as IThirdPersonController;

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