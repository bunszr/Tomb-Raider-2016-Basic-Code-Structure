using UniRx;
using UnityEngine;

public class AK47lInstaller : WeaponBaseInstaller
{
    AK47 aK47;
    CompositeDisposable disposables = new CompositeDisposable();

    protected override void Awake()
    {
        base.Awake();
        aK47 = weaponBase as AK47;

        aK47._bulletBehaviour = new NormalBulletBehaviour(aK47, aK47.normalBulletModeData);
        aK47._fireMode = new AutomaticFireBehavior(aK47, _input.WeaponInput);
        aK47._shellCasingBehaviour = new NormalShellCasingBehaviour(aK47, aK47.normalShellCasingData);
        aK47._recoilBehaviour = new PistolRecoilBehaviour(aK47, aK47.pistolRecoilBehaviourData);

        aK47.suppressorFeatureScriptable.IsOpenRP.Subscribe(OnSuppressorGain).AddTo(disposables);
        aK47.flashLightFeatureScriptable.IsOpenRP.Subscribe(OnFlashLightGain).AddTo(disposables);
    }

    private void OnDestroy() => disposables.Clear();

    public void OnSuppressorGain(bool isOpen)
    {
        SuppressorLoader suppressorLoader = new SuppressorLoader(aK47, isOpen, aK47.suppressorGO, ref aK47._muzzleBehaviour, aK47.normalMuzzleBehaviourData);
    }

    public void OnFlashLightGain(bool isOpen)
    {
        FlashLightLoader flashLightLoader = new FlashLightLoader(aK47, isOpen, aK47.flashLightAddOnData, ref aK47._flashBehaviour);
    }

    public class CommonWeaponDataLoader
    {
        public CommonWeaponDataLoader(IWeapon _weapon, WeaponDataSaveable weaponDataSaveable)
        {
        }
    }

    public class SuppressorLoader
    {
        public SuppressorLoader(IWeapon _weapon, bool hasSuppressor, GameObject suppressorGO, ref IMuzzleBehaviour _muzzleBehaviour, NormalMuzzleBehaviour.NormalMuzzleBehaviourData normalMuzzleBehaviourData)
        {
            ISuppressorAddOn _suppressorAddOn = _weapon.Transform.GetComponent<ISuppressorAddOn>();
            if (hasSuppressor) _muzzleBehaviour = new NullMuzzleBehaviour(_weapon);
            else _muzzleBehaviour = new NormalMuzzleBehaviour(_weapon, normalMuzzleBehaviourData);
            suppressorGO.SetActive(hasSuppressor);
        }
    }

    public class FlashLightLoader
    {
        public FlashLightLoader(IWeapon _weapon, bool hasFlashLight, FlashLightAddOnData flashLightAddOnData, ref IFlashBehaviour _flashBehaviour)
        {
            if (hasFlashLight) _flashBehaviour = new FlashLightBehaviour(_weapon, flashLightAddOnData);
            else _flashBehaviour = new NullFlashLightBehaviour();
            flashLightAddOnData.addOn.SetActive(hasFlashLight);
        }
    }
}