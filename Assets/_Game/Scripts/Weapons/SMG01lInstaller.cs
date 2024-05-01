using UnityEngine;

public class SMG01lInstaller : PlayerWeaponBaseInstaller
{
    protected override void Awake()
    {
        base.Awake();
        SMG01 sMG01 = weaponBase as SMG01;
    }
}