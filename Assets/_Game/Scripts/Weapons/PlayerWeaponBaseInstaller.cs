using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerWeaponBaseInstaller : WeaponBaseInstaller, IWeapon, IWeaponInstaller
{
    protected PlayerWeaponBase playerWeaponBase;

    public event System.Action<IWeapon> onEquip;
    public event System.Action<IWeapon> onUnEquip;

    public Transform Transform => transform;
    protected List<ICheck> _ChecksToFire { get; private set; } = new List<ICheck>();

    public virtual void Install()
    {
        WeaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(WeaponBase.WeaponDataScriptable.NormalAmmo);

        playerWeaponBase = WeaponBase as PlayerWeaponBase;

        AddChecksToFire(new HasBulletInTheMagazineCheck(WeaponBase));
        AddChecksToFire(new HasAimCheck(WeaponBase as IAimIsTaken));

        AddEquiptable(new WeaponReloadingFSM(playerWeaponBase._WeaponInput, WeaponBase));
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

    protected void AddChecksToFire(ICheck _check)
    {
        _ChecksToFire.Add(_check);
    }
}