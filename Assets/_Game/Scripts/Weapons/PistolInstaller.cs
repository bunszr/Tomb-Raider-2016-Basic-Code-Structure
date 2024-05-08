using System.Collections.Generic;
using UnityEngine;

public class PistolInstaller : PlayerWeaponBaseInstaller
{
    public override void Install()
    {
        base.Install();

        Pistol pistol = WeaponBase as Pistol;

        AddExtraFire(new FireAnimationBehaviour(WeaponBase._ThirdPersonController.Animator));
        AddExtraFire(new NormalBulletBehaviour(pistol, pistol.normalBulletModeData));
        AddExtraFire(new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData));

        AddEquiptable(new SingleFireBehavior(WeaponBase, _ExtraFireList, _ChecksToFire, _input.WeaponInput));
        AddEquiptable(new AimBoolSetterBehavior(WeaponBase, _input.WeaponInput));
        AddEquiptable(new NormalAimBehavior(WeaponBase, _input.WeaponInput, WeaponBase._ThirdPersonController, pistol.NormalAimBehaviorData, pistol.WeaponAimData));
    }
}