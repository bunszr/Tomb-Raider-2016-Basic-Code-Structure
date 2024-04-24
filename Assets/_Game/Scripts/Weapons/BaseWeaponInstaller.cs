using UniRx;
using UnityEngine;
using Zenject;

public abstract class BaseWeaponInstaller : MonoBehaviour
{
    protected WeaponBase weaponBase;
    [Inject] protected IInput _input;

    protected virtual void Awake()
    {
        weaponBase = transform.parent.GetComponentInChildren<WeaponBase>();
        weaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(weaponBase.weaponDataScriptable.NormalAmmo);
    }

    protected virtual void Start()
    {
    }
}