using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ReloadMagazine : Action
{
    public override TaskStatus OnUpdate()
    {
        IWeapon _weapon = transform.parent.GetComponentInChildren<IWeapon>();
        IAmmoData _ammoData = _weapon.GetAmmoData();
        _ammoData.BulletCountInMagazineRP.Value = Mathf.Min(_ammoData.MagazineCapacityRP.Value, _ammoData.CurrAmmoCapacityRP.Value);
        _ammoData.CurrAmmoCapacityRP.Value = Mathf.Max(_ammoData.CurrAmmoCapacityRP.Value - _ammoData.MagazineCapacityRP.Value, 0);
        return TaskStatus.Success;
    }
}