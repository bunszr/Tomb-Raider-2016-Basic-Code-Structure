using UnityEngine;

public struct OnAnimationStateEnterEvent
{
    public readonly AnimatorStateInfo stateInfo;
    public readonly StateInfoEnum stateInfoEnum;

    public OnAnimationStateEnterEvent(AnimatorStateInfo stateInfo, StateInfoEnum stateInfoEnum)
    {
        this.stateInfo = stateInfo;
        this.stateInfoEnum = stateInfoEnum;
    }
}