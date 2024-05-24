using System.Collections.Generic;
using UnityEngine;

public class SingleFireBehavior : FireBehaviourBase, IEquiptable
{
    float nextTime;

    public SingleFireBehavior(WeaponBase weaponBase, WeaponData weaponData, List<IExtraFire> extraFireList, List<ICheck> checkList) : base(weaponBase, weaponData, extraFireList, checkList)
    {
    }

    public override void Enter()
    {
        base.Enter();
        nextTime = Time.time;
    }

    public override void OnUpdate()
    {
        if (IM.Ins.Input.WeaponInput.HasPressedFireKey && nextTime < Time.time && AllCheckListIsTrue())
        {
            FireExtraFireList();
            weaponBase._AmmoDataRP.Value.BulletCountInMagazineRP.Value--;
            nextTime = Time.time + RateOfFireDivided100;
        }
    }
}