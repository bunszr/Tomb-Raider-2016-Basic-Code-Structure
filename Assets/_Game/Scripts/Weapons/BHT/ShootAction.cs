using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ShootAction : Action
{
    IWeapon _weapon;

    public override void OnStart()
    {
        _weapon = transform.parent.GetComponentInChildren<IWeapon>();
    }

    public override TaskStatus OnUpdate()
    {
        _weapon.Fire();
        _weapon.GetAmmoData().BulletCountInMagazineRP.Value--;
        return TaskStatus.Success;
    }
}