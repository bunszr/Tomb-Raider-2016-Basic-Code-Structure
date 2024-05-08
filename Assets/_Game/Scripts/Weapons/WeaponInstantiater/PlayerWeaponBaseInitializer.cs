using UnityEngine.Animations.Rigging;

public class PlayerWeaponBaseInitializer : WeaponInitializerBase
{
    [System.Serializable]
    public class PlayerWeaponBaseInitializerData
    {
        public WeaponAimData weaponAimData;
        public Rig bodyAndHandRig;
    }

    PlayerWeaponBase playerWeaponBase;
    PlayerWeaponBaseInitializerData data;
    IInput _input;

    public PlayerWeaponBaseInitializer(IWeapon weapon, IThirdPersonController thirdPersonController, PlayerWeaponBaseInitializerData data, IInput input) : base(weapon, thirdPersonController)
    {
        PlayerWeaponBaseInstaller playerWeaponBaseInstaller = _weapon.Transform.GetComponent<PlayerWeaponBaseInstaller>();
        playerWeaponBaseInstaller._input = input; // Fix Later
        playerWeaponBase = playerWeaponBaseInstaller.WeaponBase.GetComponent<PlayerWeaponBase>();
        this.data = data;
        _input = input;
    }

    public override void Initialize()
    {
        playerWeaponBase._ThirdPersonController = _thirdPersonController;
        playerWeaponBase.WeaponAimData = data.weaponAimData;
        playerWeaponBase.NormalAimBehaviorData.rigs = new Rig[] { data.bodyAndHandRig };

        _weapon.Transform.GetComponent<IWeaponInstaller>().Install();
    }
}