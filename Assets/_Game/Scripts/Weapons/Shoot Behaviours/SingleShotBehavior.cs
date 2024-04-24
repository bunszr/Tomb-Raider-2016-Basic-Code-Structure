using UnityEngine;

public class SingleShotBehavior : ShootBehaviourBase
{
    float nextTime;

    public SingleShotBehavior(IWeapon _weapon, IWeaponInput weaponInput) : base(_weapon, weaponInput) { }

    public override void Enter()
    {
        base.Enter();
        nextTime = Time.time;
    }

    public override void OnUpdate()
    {
        if (_weaponInput.HasPressedFireKey && weaponCheckFactory.Check(WeaponCheckType.HasBulletInTheMagazineCheck) && nextTime < Time.time)
        {
            _weapon.Fire();
            _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value--;
            nextTime = Time.time + RateOfFireDivided100;
        }
    }
}