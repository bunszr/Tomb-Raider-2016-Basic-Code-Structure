using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AK47lInstaller : PlayerWeaponBaseInstaller
{
    AK47 aK47;
    CompositeDisposable disposables = new CompositeDisposable();

    public override void Install()
    {
        base.Install();
        aK47 = WeaponBase as AK47;

        AddExtraFire(new NormalBulletBehaviour(aK47, aK47.normalBulletModeData));
        AddExtraFire(new NormalShellCasingBehaviour(aK47, aK47.normalShellCasingData));

        AddEquiptable(new AutomaticFireBehavior(WeaponBase, _ExtraFireList, _ChecksToFire));
        AddEquiptable(new AimBoolSetterBehavior(WeaponBase));
        AddEquiptable(new NormalAimBehavior(WeaponBase, WeaponBase._Animator, aK47.NormalAimBehaviorData, aK47.WeaponAimData));

        aK47.suppressorFeatureScriptable.IsOpenRP.Subscribe(OnSuppressorGain).AddTo(disposables);
        aK47.flashLightFeatureScriptable.IsOpenRP.Subscribe(OnFlashLightGain).AddTo(disposables);
    }

    private void OnDestroy() => disposables.Clear();

    public void OnSuppressorGain(bool isOpen)
    {
        (WeaponBase as ISuppressorAddOn).SuppressorGO.SetActive(isOpen);
        if (!isOpen) AddExtraFire(new NormalMuzzleBehaviour(aK47.normalMuzzleBehaviourData));
    }

    public void OnFlashLightGain(bool isOpen)
    {
        if (isOpen) AddEquiptable(new FlashLightBehaviour(WeaponBase));
    }
}