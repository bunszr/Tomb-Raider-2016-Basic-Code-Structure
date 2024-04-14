using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    [SerializeField] WeaponTypeScriptable weaponTypeScriptable;

    public ReactiveProperty<IAmmoData> _ammoDataRP;

    [ShowInInspector] public IFireBehaviour _fireMode;

    [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
    public Transform Transform => transform;
    public WeaponTypeScriptable WeaponTypeScriptable => weaponTypeScriptable;

    public abstract void Fire();

    [Button]
    public virtual void Equip()
    {
        ChangeActiveSelfMVC(true);
        _fireMode.Enter();
    }

    [Button]
    public virtual void Unequip()
    {
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