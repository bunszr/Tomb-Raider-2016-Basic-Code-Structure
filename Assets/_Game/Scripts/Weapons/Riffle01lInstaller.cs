using System.Linq;
using CampSite;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class Riffle01lInstaller : MonoBehaviour
{
    private void Awake()
    {
        Riffle01 riffle01 = transform.parent.GetComponentInChildren<Riffle01>();

        riffle01._bulletBehaviour = new NormalBulletBehaviour(riffle01, riffle01.normalBulletModeData);
        riffle01._fireMode = new AutomaticFireBehavior(riffle01, riffle01.automaticFireBehaviorData);
        riffle01._shellCasingBehaviour = new NormalShellCasingBehaviour(riffle01, riffle01.normalShellCasingData);
        riffle01._recoilBehaviour = new PistolRecoilBehaviour(riffle01, riffle01.pistolRecoilBehaviourData);

        riffle01.normalAmmo = new NormalAmmo();
        riffle01.fireAmmo = new FireAmmo();
        riffle01._ammoDataRP = new ReactiveProperty<IAmmoData>(riffle01.normalAmmo);

        Load();
    }

    public void Load()
    {
        Riffle01 riffle01 = GetComponent<Riffle01>();
        IWeapon _weapon = GetComponent<IWeapon>();
        var data = FileHandler.ReadFromJSON<AK47FeatureSaver.Data>(riffle01.WeaponTypeScriptable.WeaponName);
        CommonWeaponDataLoader commonWeaponDataResolverDecorator = new CommonWeaponDataLoader(_weapon, data.weaponDataSaveable);
        SuppressorLoader suppressorLoader = new SuppressorLoader(_weapon, data.hasSuppressor, riffle01.suppressorGO, riffle01._muzzleBehaviour, new NormalMuzzleBehaviour(riffle01, riffle01.normalMuzzleBehaviourData));
        FlashLightLoader flashLightLoader = new FlashLightLoader(_weapon, data.hasFlashLight, riffle01.flashLightAddOnData.addOn, riffle01._flashBehaviour, new FlashLightBehaviour(riffle01, riffle01.flashLightAddOnData));
    }
}

public class CommonWeaponDataLoader
{
    public CommonWeaponDataLoader(IWeapon _weapon, WeaponDataSaveable weaponDataSaveable)
    {
        _weapon.WeaponData = new WeaponData(weaponDataSaveable);
    }
}

public class SuppressorLoader
{
    public SuppressorLoader(IWeapon _weapon, bool hasSuppressor, GameObject suppressorGO, IMuzzleBehaviour _muzzleBehaviour, NormalMuzzleBehaviour normalMuzzleBehaviour)
    {
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