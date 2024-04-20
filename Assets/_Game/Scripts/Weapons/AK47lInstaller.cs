using UniRx;
using UnityEngine;

public class AK47lInstaller : MonoBehaviour
{
    AK47 aK47;
    AK47WeaponDataScriptable ak47WeaponDataScriptable;

    private void Awake()
    {
        aK47 = transform.parent.GetComponentInChildren<AK47>();

        aK47._bulletBehaviour = new NormalBulletBehaviour(aK47, aK47.normalBulletModeData);
        aK47._fireMode = new AutomaticFireBehavior(aK47, aK47.automaticFireBehaviorData);
        aK47._shellCasingBehaviour = new NormalShellCasingBehaviour(aK47, aK47.normalShellCasingData);
        aK47._recoilBehaviour = new PistolRecoilBehaviour(aK47, aK47.pistolRecoilBehaviourData);

        ak47WeaponDataScriptable = aK47.weaponDataScriptable as AK47WeaponDataScriptable;
        if (GameDataScriptable.Ins.loadWeaponDataFromJSONinEditor) ak47WeaponDataScriptable.LoadFromJSON();
        else ak47WeaponDataScriptable.LoadFromItSelf();

        aK47.suppressorFeatureScriptable.IsOpenRP.Subscribe(OnSuppressorGain);
        aK47.flashLightFeatureScriptable.IsOpenRP.Subscribe(OnFlashLightGain);
    }

    private void OnDestroy()
    {
        ak47WeaponDataScriptable.Save();
    }

    public void OnSuppressorGain(bool isOpen)
    {
        SuppressorLoader suppressorLoader = new SuppressorLoader(aK47, isOpen, aK47.suppressorGO, aK47._muzzleBehaviour, new NormalMuzzleBehaviour(aK47, aK47.normalMuzzleBehaviourData));
    }

    public void OnFlashLightGain(bool isOpen)
    {
        FlashLightLoader flashLightLoader = new FlashLightLoader(aK47, isOpen, aK47.flashLightAddOnData.addOn, aK47._flashBehaviour, new FlashLightBehaviour(aK47, aK47.flashLightAddOnData));
    }

    public class CommonWeaponDataLoader
    {
        public CommonWeaponDataLoader(IWeapon _weapon, WeaponDataSaveable weaponDataSaveable)
        {
        }
    }

    public class SuppressorLoader
    {
        public SuppressorLoader(IWeapon _weapon, bool hasSuppressor, GameObject suppressorGO, IMuzzleBehaviour _muzzleBehaviour, NormalMuzzleBehaviour normalMuzzleBehaviour)
        {
            ISuppressorAddOn _suppressorAddOn = _weapon.Transform.GetComponent<ISuppressorAddOn>();
            if (hasSuppressor) _muzzleBehaviour = new NullMuzzleBehaviour(_weapon);
            else _muzzleBehaviour = normalMuzzleBehaviour;
            suppressorGO.SetActive(hasSuppressor);
        }
    }

    public class FlashLightLoader
    {
        public FlashLightLoader(IWeapon _weapon, bool hasFlashLight, GameObject flashLightGO, IFlashBehaviour _flashBehaviour, FlashLightBehaviour flashLightBehaviour)
        {
            if (hasFlashLight) _flashBehaviour = flashLightBehaviour;
            else _flashBehaviour = new NullFlashLightBehaviour();
            flashLightGO.SetActive(hasFlashLight);
        }
    }
}