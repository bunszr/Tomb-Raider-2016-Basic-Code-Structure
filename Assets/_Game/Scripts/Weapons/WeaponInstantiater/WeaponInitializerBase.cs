
public abstract class WeaponInitializerBase
{
    protected IWeapon _weapon;
    protected IThirdPersonController _thirdPersonController;

    public WeaponInitializerBase(IWeapon weapon, IThirdPersonController thirdPersonController)
    {
        _weapon = weapon;
        _thirdPersonController = thirdPersonController;
    }

    public abstract void Initialize();
}