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
            weaponBase.weaponDataScriptable = weaponBase.weaponDataScriptable.CreateInstance();
            weaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(weaponBase.weaponDataScriptable.NormalAmmo);
            _checksToFire = new List<ICheck>()
            {
                new HasBulletInTheMagazineCheck(weaponBase),
                new HasAimCheck(weaponBase as IAimIsTaken),
            };
        }

        protected virtual void Start() { }

        [Button]
        public virtual void Equip()
        {
            _equipableList.ForEach(x => x.Enter());
            onEquip?.Invoke(this);
        }

        [Button]
        public virtual void Unequip()
        {
            _equipableList.ForEach(x => x.Exit());
            onUnEquip?.Invoke(this);
        }
    }
}