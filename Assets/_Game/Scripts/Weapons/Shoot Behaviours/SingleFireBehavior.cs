using System.Collections.Generic;
using UnityEngine;

public class SingleFireBehavior : FireBehaviourBase, IEquiptable
{
    float nextTime;
    protected IWeaponInput _weaponInput;

    public SingleFireBehavior(WeaponBase weaponBase, List<IExtraFire> extraFireList, List<ICheck> checkList, IWeaponInput weaponInput) : base(weaponBase, extraFireList, checkList)
    {
        _weaponInput = weaponInput;
    }

    public override void Enter()
    {
        base.Enter();
        nextTime = Time.time;
    }

    public override void OnUpdate()
    {
        if (_weaponInput.HasPressedFireKey && nextTime < Time.time && AllCheckListIsTrue())
        {
            FireExtraFireList();
            weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Value--;
            nextTime = Time.time + RateOfFireDivided100;
        }
    }
}