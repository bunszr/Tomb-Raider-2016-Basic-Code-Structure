using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public WeaponDataScriptable weaponDataScriptable;
    public System.Action<IWeapon> onEquip;
    public System.Action<IWeapon> onUnEquip;

    public ReactiveProperty<IAmmoData> _ammoDataRP;

    [ShowInInspector] public IFireBehaviour _fireMode;

    [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
    public Transform Transform => transform;

    public abstract void Fire();

    [Button]
    public virtual void Equip()
    {
        onEquip?.Invoke(this);
        ChangeActiveSelfMVC(true);
        _fireMode.Enter();
    }

    [Button]
    public virtual void Unequip()
    {
        onUnEquip?.Invoke(this);
        _fireMode.Exit();
        ChangeActiveSelfMVC(false);
    }

    public void ChangeActiveSelfMVC(bool active)
    {
        transform.parent.gameObject.SetActive(active);
    }

    public IAmmoData GetAmmoData()
    {
        return _ammoDataRP.Value;
    }
}