using Lean.Pool;
using UnityEngine;

public abstract class BaseMuzzleBehaviour : IMuzzleBehaviour
{
    protected IWeapon _weapon;

    protected BaseMuzzleBehaviour(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public virtual void Execute()
    {
    }
}