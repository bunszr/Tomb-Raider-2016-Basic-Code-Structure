using System.Collections.Generic;

public class FireBehaviourBase : IFireBehaviour
{
    protected WeaponBase weaponBase;
    protected List<IExtraFire> _extraFireList;
    protected WeaponCheckFactory weaponCheckFactory;

    protected float RateOfFireDivided100 => weaponBase.weaponDataScriptable.WeaponData.RateOfFireRP.Value / 100f;

    public FireBehaviourBase(WeaponBase weaponBase, List<IExtraFire> extraFireList)
    {
        weaponCheckFactory = new WeaponCheckFactory(weaponBase);
        this.weaponBase = weaponBase;
        this._extraFireList = extraFireList;
    }

    protected void FireExtraFireList()
    {
        if (_extraFireList != null) for (int i = 0; i < _extraFireList.Count; i++) _extraFireList[i].Fire();
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);
    public virtual void OnUpdate() { }
}