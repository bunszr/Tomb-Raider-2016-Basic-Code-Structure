using UnityEngine;

public class ShotgunInstaller : PlayerWeaponBaseInstaller
{
    Shotgun shotgun;

    protected override void Awake()
    {
        base.Awake();
        shotgun = weaponBase as Shotgun;
    }
}