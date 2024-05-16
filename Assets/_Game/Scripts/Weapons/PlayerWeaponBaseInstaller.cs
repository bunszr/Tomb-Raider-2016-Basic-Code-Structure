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

    public ReactiveProperty<bool> HasEquipRP { get; private set; } = new ReactiveProperty<bool>();

    public virtual void Install()
    {
        WeaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(WeaponBase.WeaponDataScriptable.NormalAmmo);

        playerWeaponBase = WeaponBase as PlayerWeaponBase;

        AddChecksToFire(new HasBulletInTheMagazineCheck(WeaponBase));
        AddChecksToFire(new HasAimCheck(WeaponBase as IAimIsTaken));

        AddEquiptable(new WeaponReloadingFSM(WeaponBase));

        AddExtraFire(new FireAnimationBehaviour(WeaponBase._ThirdPersonController.Animator, WeaponBase.WeaponDataScriptable.weaponAnimationData.fireAnimName));
    }

    protected virtual void Start() { }

    [Button]
    public virtual void Equip()
    {
        if (HasEquipRP.Value) Debug.LogError("The weapon already equiped", transform);
        _EquipableList.ForEach(x => x.Enter());
        onEquip?.Invoke(this);
        HasEquipRP.Value = true;
    }

    [Button]
    public virtual void Unequip()
    {
        if (!HasEquipRP.Value) Debug.LogError("The weapon already unequiped", transform);
        _EquipableList.ForEach(x => x.Exit());
        onUnEquip?.Invoke(this);
        HasEquipRP.Value = false;
    }

    protected void AddChecksToFire(ICheck _check)
    {
        _ChecksToFire.Add(_check);
    }
}