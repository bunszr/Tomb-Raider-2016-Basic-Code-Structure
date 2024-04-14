using Sirenix.OdinInspector;
using UnityEngine;

public class Riffle01 : WeaponBase, ISuppressorAddOn, IFlashLightAddOn
{
    public FireAmmo fireAmmo;
    public NormalAmmo normalAmmo;

    public AutomaticFireBehavior.AutomaticFireBehaviorData automaticFireBehaviorData;
    public NormalBulletBehaviour.NormalBulletBehaviourData normalBulletModeData;
    public NormalShellCasingBehaviour.NormalShellCasingBehaviourData normalShellCasingData;
    public PistolRecoilBehaviour.PistolRecoilBehaviourData pistolRecoilBehaviourData;
    public NormalMuzzleBehaviour.NormalMuzzleBehaviourData normalMuzzleBehaviourData;
    public FlashLightAddOnData flashLightAddOnData;
    public GameObject suppressorGO;

    [ShowInInspector] public IBulletBehaviour _bulletBehaviour;
    [ShowInInspector] public IShellCasingBehaviour _shellCasingBehaviour;
    [ShowInInspector] public IRecoilBehaviour _recoilBehaviour;
    [ShowInInspector] public IFlashBehaviour _flashBehaviour;
    [ShowInInspector] public IMuzzleBehaviour _muzzleBehaviour;

    public GameObject SuppressorGO => suppressorGO;
    public FlashLightAddOnData FlashLightAddOnData => flashLightAddOnData;

    public override void Fire()
    {
        _bulletBehaviour.Fire();
        _shellCasingBehaviour.Execute();
        _recoilBehaviour.Execute();
        _muzzleBehaviour.Execute();
    }

    public override void Equip()
    {
        base.Equip();
        _flashBehaviour.Enter();
    }

    public override void Unequip()
    {
        base.Unequip();
        _flashBehaviour.Exit();
    }
}

public interface ISuppressorAddOn
{
    GameObject SuppressorGO { get; }
}

public interface IFlashLightAddOn
{
    FlashLightAddOnData FlashLightAddOnData { get; }
}

[System.Serializable]
public class FlashLightAddOnData
{
    public GameObject addOn;
    public Light light;
}