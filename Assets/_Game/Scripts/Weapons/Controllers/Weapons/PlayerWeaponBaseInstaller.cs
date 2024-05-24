using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerWeaponBaseInstaller : WeaponBaseInstaller, IWeapon, IWeaponInstaller
{
    protected PlayerWeaponBase playerWeaponBase;

    public Transform Transform => transform;

    public ReactiveProperty<bool> HasEquipRP { get; private set; } = new ReactiveProperty<bool>();

    public virtual void Install()
    {
        playerWeaponBase = WeaponBase as PlayerWeaponBase;

        WeaponBase._AmmoDataRP = new ReactiveProperty<IAmmoData>(playerWeaponBase.WeaponDataScriptable.NormalAmmo);

        AddChecksToFire(new HasBulletInTheMagazineCheck(WeaponBase._AmmoDataRP));
        AddChecksToFire(new HasAimCheck(WeaponBase as IAimIsTaken));

        AddEquiptable(new WeaponReloadingFSM(WeaponBase));

        AddExtraFire(new FireAnimationBehaviour(WeaponBase._Animator.Animator, WeaponBase.WeaponAnimationData.fireAnimName));
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
        if (!HasEquipRP.Value) Debug.LogError("The weapon already unequiped", transform);
        _EquipableList.ForEach(x => x.Exit());
        HasEquipRP.Value = false;
    }

}