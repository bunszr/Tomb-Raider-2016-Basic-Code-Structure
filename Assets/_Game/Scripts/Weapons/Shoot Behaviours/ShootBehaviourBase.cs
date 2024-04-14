

public class ShootBehaviourBase : IFireBehaviour
{
    protected IWeapon _weapon;

    public ShootBehaviourBase(IWeapon _weapon)
    {
        this._weapon = _weapon;
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