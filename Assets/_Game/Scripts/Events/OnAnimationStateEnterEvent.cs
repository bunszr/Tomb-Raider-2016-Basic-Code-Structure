using UnityEngine;

public struct OnAnimationStateEnterEvent
{
    public readonly Animator animator;
    public readonly AnimatorStateInfo stateInfo;
    public readonly StateInfoEnum stateInfoEnum;
    public readonly int layerIndex;

    public OnAnimationStateEnterEvent(Animator animator, AnimatorStateInfo stateInfo, StateInfoEnum stateInfoEnum, int layerIndex)
    {
        this.animator = animator;
        this.stateInfo = stateInfo;
        this.stateInfoEnum = stateInfoEnum;
        this.layerIndex = layerIndex;
    }
}