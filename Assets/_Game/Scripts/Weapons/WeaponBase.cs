using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public WeaponDataScriptable weaponDataScriptable;
    public System.Action<IWeapon> onEquip;
    public System.Action<IWeapon> onUnEquip;

    public NormalAimBehavior.NormalAimBehaviorData normalAimBehaviorData;

    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoRP { get; set; }

    [ShowInInspector] public IFireBehaviour _fireMode;
    [ShowInInspector] public IAimBehaviour _aimBehaviour;
    [ShowInInspector] public IShotAnim _shotAnim;

    public Transform Transform => transform;

    public virtual void Fire()
    {
        _shotAnim.Fire();
    }

    [Button]
    public virtual void Equip()
    {
        ChangeActiveSelfMVC(true);
        onEquip?.Invoke(this);
        _fireMode.Enter();
        _aimBehaviour.Enter();
    }

    [Button]
    public virtual void Unequip()
    {
        onUnEquip?.Invoke(this);
        _fireMode.Exit();
        _aimBehaviour.Exit();
        ChangeActiveSelfMVC(false);
    }

    public void ChangeActiveSelfMVC(bool active)
    {
        transform.parent.gameObject.SetActive(active);
    }
}