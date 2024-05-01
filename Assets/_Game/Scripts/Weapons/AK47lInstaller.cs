using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AK47lInstaller : PlayerWeaponBaseInstaller
{
    AK47 aK47;
    [SerializeField] Animator animator;
    [SerializeField] LivingEntity livingEntity;

    CompositeDisposable disposables = new CompositeDisposable();

    protected override void Awake()
    {
        base.Awake();
        aK47 = weaponBase as AK47;

        _extraFireList = new List<IExtraFire>()
        {
            new FireAnimationBehaviour(animator),
            new NormalBulletBehaviour(aK47, aK47.normalBulletModeData),
            new NormalShellCasingBehaviour(aK47, aK47.normalShellCasingData),
            // new NormalMuzzleBehaviour()
        };

        _equipableList = new List<IEquiptable>()
        {
            new AutomaticFireBehavior(weaponBase, _extraFireList, _input.WeaponInput),
            new NormalAimBehavior(weaponBase, _input.WeaponInput, livingEntity, aK47.normalAimBehaviorData, aK47.weaponAimData),
        };

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