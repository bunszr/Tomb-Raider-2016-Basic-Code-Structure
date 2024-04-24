using FSM;

public class WeaponStateBase : StateBase
{
    protected WeaponBase weaponBase;
    protected IWeapon _weapon;

    public WeaponStateBase(IWeapon _weapon, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
    {
        this._weapon = _weapon;
        weaponBase = _weapon.Transform.GetComponent<WeaponBase>();
    }
}