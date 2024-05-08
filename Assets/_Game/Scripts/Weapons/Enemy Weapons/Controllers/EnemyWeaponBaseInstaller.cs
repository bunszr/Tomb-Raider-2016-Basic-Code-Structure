using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public class EnemyWeaponBaseInstaller : WeaponBaseInstaller, IWeapon
    {
        public event System.Action<IWeapon> onEquip;
        public event System.Action<IWeapon> onUnEquip;

        public Transform Transform => transform;
        protected List<ICheck> _checksToFire;

        protected virtual void Awake()
        {
            WeaponBase.WeaponDataScriptable = WeaponBase.WeaponDataScriptable.CreateInstance();
            WeaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(WeaponBase.WeaponDataScriptable.NormalAmmo);
            _checksToFire = new List<ICheck>()
            {
                new HasBulletInTheMagazineCheck(WeaponBase),
                new HasAimCheck(WeaponBase as IAimIsTaken),
            };
        }

        protected virtual void Start() { }

        [Button]
        public virtual void Equip()
        {
            _EquipableList.ForEach(x => x.Enter());
            onEquip?.Invoke(this);
        }

        [Button]
        public virtual void Unequip()
        {
            _EquipableList.ForEach(x => x.Exit());
            onUnEquip?.Invoke(this);
        }
    }
}