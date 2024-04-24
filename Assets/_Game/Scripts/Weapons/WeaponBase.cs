using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public WeaponDataScriptable weaponDataScriptable;
    public System.Action<IWeapon> onEquip;
    public System.Action<IWeapon> onUnEquip;

    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoRP { get; set; }

    [ShowInInspector] public IFireBehaviour _fireMode;

    public Transform Transform => transform;

    public abstract void Fire();

    [Button]
    public virtual void Equip()
    {
        ChangeActiveSelfMVC(true);
        onEquip?.Invoke(this);
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
}