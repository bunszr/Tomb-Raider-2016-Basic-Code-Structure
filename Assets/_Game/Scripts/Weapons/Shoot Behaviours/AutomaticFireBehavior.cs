using UnityEngine;

public class AutomaticFireBehavior : ShootBehaviourBase, IFireBehaviour
{
    float nextTime;

    public AutomaticFireBehavior(IWeapon _weapon, IWeaponInput weaponInput) : base(_weapon, weaponInput) { }

    public override void Enter()
    {
        base.Enter();
        nextTime = Time.time;
    }

    public override void OnUpdate()
    {
        if (_weaponInput.HasHoldingFireKey && weaponCheckFactory.Check(WeaponCheckType.HasBulletInTheMagazineCheck) && nextTime < Time.time)
        {
            _weapon.Fire();
            _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value--;
            nextTime = Time.time + RateOfFireDivided100;
        }
    }
}