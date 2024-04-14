using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ReloadMagazine : Action
{
    public override TaskStatus OnUpdate()
    {
        IWeapon _weapon = transform.parent.GetComponentInChildren<IWeapon>();
        IAmmoData _ammoData = _weapon.GetAmmoData();
        _ammoData.CurrAmmoRP.Value = Mathf.Min(_ammoData.MagazineCapacity.Value, _ammoData.TotalAmmoRP.Value);
        _ammoData.TotalAmmoRP.Value = Mathf.Max(_ammoData.TotalAmmoRP.Value - _ammoData.MagazineCapacity.Value, 0);
        return TaskStatus.Success;
    }
}