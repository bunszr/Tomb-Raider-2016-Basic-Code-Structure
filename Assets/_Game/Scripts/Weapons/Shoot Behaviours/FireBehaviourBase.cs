using System.Collections.Generic;

public class FireBehaviourBase : IFireBehaviour
{
    protected WeaponBase weaponBase;
    protected List<IExtraFire> _extraFireList;
    protected List<ICheck> _checkList;

    protected float RateOfFireDivided100 => weaponBase.weaponDataScriptable.WeaponData.RateOfFireRP.Value / 100f;

    public FireBehaviourBase(WeaponBase weaponBase, List<IExtraFire> extraFireList, List<ICheck> checkList)
    {
        this.weaponBase = weaponBase;
        this._extraFireList = extraFireList;
        this._checkList = checkList;
    }

    protected void FireExtraFireList()
    {
        if (_extraFireList != null) for (int i = 0; i < _extraFireList.Count; i++) _extraFireList[i].Fire();
    }

    protected bool AllCheckListIsTrue()
    {
        if (_checkList != null)
        {
            for (int i = 0; i < _checkList.Count; i++) if (!_checkList[i].Check()) return false;
        }
        return true;
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);
    public virtual void OnUpdate() { }
}