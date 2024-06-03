using UnityEngine;

public class SMG01lInstaller : PlayerWeaponBaseInstaller
{
    SMG01 smg;

    public override void Install()
    {
        base.Install();
        smg = WeaponBase as SMG01;

        AddExtraFire(new SplineBulletBehaviour(smg, smg.splineBulletBehaviourData, smg.WeaponAimData));
        AddExtraFire(new NormalShellCasingBehaviour(smg, smg.normalShellCasingData));

        AddEquiptable(new AutomaticFireBehavior(WeaponBase, playerWeaponBase.WeaponDataScriptable.WeaponData, _ExtraFireList, _ChecksToFire));
        AddEquiptable(new AimBoolSetterBehavior(WeaponBase));
        AddEquiptable(new NormalAimBehavior(WeaponBase, WeaponBase._Animator, smg.NormalAimBehaviorData, smg.WeaponAimData));
    }
}