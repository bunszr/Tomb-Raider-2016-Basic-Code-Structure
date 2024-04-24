

public class ShootBehaviourBase : IFireBehaviour
{
    protected WeaponBase weaponBase;
    protected IWeapon _weapon;
    protected IWeaponInput _weaponInput;

    protected WeaponCheckFactory weaponCheckFactory;

    protected float RateOfFireDivided100 => weaponBase.weaponDataScriptable.WeaponData.RateOfFireRP.Value / 100f;

    public ShootBehaviourBase(IWeapon _weapon, IWeaponInput weaponInput)
    {
        this._weapon = _weapon;
        weaponBase = _weapon.Transform.GetComponent<WeaponBase>();
        _weaponInput = weaponInput;

        weaponCheckFactory = new WeaponCheckFactory(_weapon);
    }

    public virtual void Enter()
    {
        MonoEvents monoEvents = _weapon.Transform.GetComponent<MonoEvents>();
        monoEvents.onUpdate += OnUpdate;
    }

    public virtual void Exit()
    {
        MonoEvents monoEvents = _weapon.Transform.GetComponent<MonoEvents>();
        monoEvents.onUpdate -= OnUpdate;
    }

    public virtual void OnUpdate()
    {

    }
}