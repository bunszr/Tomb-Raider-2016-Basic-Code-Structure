using Lean.Pool;
using UnityEngine;

public class NormalMuzzleBehaviour : BaseMuzzleBehaviour
{
    [System.Serializable]
    public class NormalMuzzleBehaviourData
    {

    }

    public NormalMuzzleBehaviourData data;

    public NormalMuzzleBehaviour(IWeapon weapon, NormalMuzzleBehaviourData data) : base(weapon)
    {
        this.data = data;
    }

    public override void Execute()
    {
        // Add muzzle effect
    }
}