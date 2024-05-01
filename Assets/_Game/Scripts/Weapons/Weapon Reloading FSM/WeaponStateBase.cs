using FSM;

public class WeaponStateBase : StateBase
{
    protected WeaponBase weaponBase;

    public WeaponStateBase(WeaponBase weaponBase, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
    {
        this.weaponBase = weaponBase;
    }
}