
public class AimBehaviourBase : IAimBehaviour
{
    protected WeaponBase weaponBase;

    protected WeaponCheckFactory weaponCheckFactory;

    protected float RateOfFireDivided100 => weaponBase.weaponDataScriptable.WeaponData.RateOfFireRP.Value / 100f;

    public AimBehaviourBase(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
        weaponBase = weaponBase.GetComponent<WeaponBase>();

        weaponCheckFactory = new WeaponCheckFactory(weaponBase);
    }

    public virtual void Enter() => UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    public virtual void Exit() => UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);

    public virtual void OnUpdate() { }
}