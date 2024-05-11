using UnityEngine;
using FSM;

public abstract class LivingStateBase : StateBase
{
    protected LivingEntity living;
    protected Transform transform => living.transform;

    protected LivingStateBase(LivingEntity livingEntity, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
    {
        this.living = livingEntity;
    }
}