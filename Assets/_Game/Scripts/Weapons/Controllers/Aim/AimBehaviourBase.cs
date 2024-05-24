
public class AimBehaviourBase : IAimBehaviour
{
    protected WeaponBase weaponBase;

    public AimBehaviourBase(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);

    public virtual void OnUpdate() { }
}