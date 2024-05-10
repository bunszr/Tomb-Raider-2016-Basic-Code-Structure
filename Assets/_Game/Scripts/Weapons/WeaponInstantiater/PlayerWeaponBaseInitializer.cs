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
    IWeaponInput _weaponInput;

    public PlayerWeaponBaseInitializer(IWeapon weapon, IThirdPersonController thirdPersonController, PlayerWeaponBaseInitializerData data, IWeaponInput _weaponInput) : base(weapon, thirdPersonController)
    {
        PlayerWeaponBaseInstaller playerWeaponBaseInstaller = _weapon.Transform.GetComponent<PlayerWeaponBaseInstaller>();
        playerWeaponBase = playerWeaponBaseInstaller.WeaponBase.GetComponent<PlayerWeaponBase>();
        this.data = data;
        this._weaponInput = _weaponInput;
    }

    public override void Initialize()
    {
        playerWeaponBase._WeaponInput = _weaponInput;
        playerWeaponBase._ThirdPersonController = _thirdPersonController;
        playerWeaponBase.WeaponAimData = data.weaponAimData;
        playerWeaponBase.NormalAimBehaviorData.rigs = new Rig[] { data.bodyAndHandRig };

        _weapon.Transform.GetComponent<IWeaponInstaller>().Install();
    }
}