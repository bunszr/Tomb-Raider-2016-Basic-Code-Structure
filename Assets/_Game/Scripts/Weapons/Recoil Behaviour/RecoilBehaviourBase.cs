using UnityEngine;

public class RecoilBehaviourBase : IRecoilBehaviour
{
    protected IWeapon _weapon;
    protected Transform Transform => _weapon.Transform;

    public RecoilBehaviourBase(IWeapon _weapon)
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

    public virtual void Execute()
    {
    }

    public virtual void OnUpdate()
    {
    }
}