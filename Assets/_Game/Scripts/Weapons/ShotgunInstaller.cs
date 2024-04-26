using UnityEngine;

public class ShotgunInstaller : WeaponBaseInstaller
{
    Shotgun shotgun;

    protected override void Awake()
    {
        base.Awake();
        shotgun = weaponBase as Shotgun;

        shotgun._bulletBehaviour = new ScatterBulletBehaviour(weaponBase, shotgun.scatterBulletBehaviourData);
        shotgun._fireMode = new SingleShotBehavior(weaponBase, _input.WeaponInput);
    }
}