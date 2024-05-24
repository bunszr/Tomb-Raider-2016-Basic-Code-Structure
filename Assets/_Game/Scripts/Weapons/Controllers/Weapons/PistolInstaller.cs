using System.Collections.Generic;
using UnityEngine;

public class PistolInstaller : PlayerWeaponBaseInstaller
{
    public override void Install()
    {
        base.Install();

        Pistol pistol = WeaponBase as Pistol;

        AddExtraFire(new NormalBulletBehaviour(pistol, pistol.normalBulletModeData));
        AddExtraFire(new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData));

        AddEquiptable(new SingleFireBehavior(WeaponBase, playerWeaponBase.WeaponDataScriptable.WeaponData, _ExtraFireList, _ChecksToFire));
        AddEquiptable(new AimBoolSetterBehavior(WeaponBase));
        AddEquiptable(new NormalAimBehavior(WeaponBase, WeaponBase._Animator, pistol.NormalAimBehaviorData, pistol.WeaponAimData));
    }
}