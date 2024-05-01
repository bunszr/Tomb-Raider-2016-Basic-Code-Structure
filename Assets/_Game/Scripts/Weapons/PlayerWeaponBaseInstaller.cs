using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerWeaponBaseInstaller : WeaponBaseInstaller, IWeapon
{
    [Inject] protected IInput _input;

    public event System.Action<IWeapon> onEquip;
    public event System.Action<IWeapon> onUnEquip;

    public Transform Transform => transform;

    protected virtual void Awake()
    {
        weaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(weaponBase.weaponDataScriptable.NormalAmmo);
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