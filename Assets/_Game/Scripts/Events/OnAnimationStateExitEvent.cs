using UnityEngine;

public struct OnAnimationStateExitEvent
{
    public readonly Animator animator;
    public readonly AnimatorStateInfo stateInfo;
    public readonly StateInfoEnum stateInfoEnum;
    public readonly int layerIndex;

    public OnAnimationStateExitEvent(Animator animator, AnimatorStateInfo stateInfo, StateInfoEnum stateInfoEnum, int layerIndex)
    {
        this.animator = animator;
        this.stateInfo = stateInfo;
        this.stateInfoEnum = stateInfoEnum;
        this.layerIndex = layerIndex;
    }
}