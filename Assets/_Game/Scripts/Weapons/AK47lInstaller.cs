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

        AddExtraFire(new FireAnimationBehaviour(WeaponBase._ThirdPersonController.Animator));
        AddExtraFire(new NormalBulletBehaviour(aK47, aK47.normalBulletModeData));
        AddExtraFire(new NormalShellCasingBehaviour(aK47, aK47.normalShellCasingData));

        AddEquiptable(new AutomaticFireBehavior(WeaponBase, _ExtraFireList, _ChecksToFire, _input.WeaponInput));
        AddEquiptable(new AimBoolSetterBehavior(WeaponBase, _input.WeaponInput));
        AddEquiptable(new NormalAimBehavior(WeaponBase, _input.WeaponInput, WeaponBase._ThirdPersonController, aK47.NormalAimBehaviorData, aK47.WeaponAimData));

        aK47.suppressorFeatureScriptable.IsOpenRP.Subscribe(OnSuppressorGain).AddTo(disposables);
        aK47.flashLightFeatureScriptable.IsOpenRP.Subscribe(OnFlashLightGain).AddTo(disposables);
    }

    private void OnDestroy() => disposables.Clear();

    public void OnSuppressorGain(bool isOpen)
    {

    }

    public void OnFlashLightGain(bool isOpen)
    {
        // FlashLightLoader flashLightLoader = new FlashLightLoader(aK47, isOpen, aK47.flashLightAddOnData, ref aK47._flashBehaviour);
    }

    // public class SuppressorLoader
    // {
    //     public SuppressorLoader(IWeapon weaponBase, bool hasSuppressor, GameObject suppressorGO, ref IMuzzleBehaviour _muzzleBehaviour, NormalMuzzleBehaviour.NormalMuzzleBehaviourData normalMuzzleBehaviourData)
    //     {
    //         ISuppressorAddOn _suppressorAddOn = weaponBase.Transform.GetComponent<ISuppressorAddOn>();
    //         if (hasSuppressor) _muzzleBehaviour = new NullMuzzleBehaviour(weaponBase);
    //         else _muzzleBehaviour = new NormalMuzzleBehaviour(weaponBase, normalMuzzleBehaviourData);
    //         suppressorGO.SetActive(hasSuppressor);
    //     }
    // }

    // public class FlashLightLoader
    // {
    //     public FlashLightLoader(IWeapon weaponBase, bool hasFlashLight, FlashLightAddOnData flashLightAddOnData, ref IFlashBehaviour _flashBehaviour)
    //     {
    //         if (hasFlashLight) _flashBehaviour = new FlashLightBehaviour(weaponBase, flashLightAddOnData);
    //         else _flashBehaviour = new NullFlashLightBehaviour();
    //         flashLightAddOnData.addOn.SetActive(hasFlashLight);
    //     }
    // }
}