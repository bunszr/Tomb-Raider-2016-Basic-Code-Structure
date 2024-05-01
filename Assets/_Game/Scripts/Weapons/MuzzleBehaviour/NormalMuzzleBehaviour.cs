using Lean.Pool;
using UnityEngine;

public class NormalMuzzleBehaviour : BaseMuzzleBehaviour
{
    [System.Serializable]
    public class NormalMuzzleBehaviourData
    {

    }

    public NormalMuzzleBehaviourData data;

    public NormalMuzzleBehaviour(WeaponBase weapon, NormalMuzzleBehaviourData data) : base(weapon)
    {
        this.data = data;
    }

    public override void Fire()
    {
        // Add muzzle effect
    }
}