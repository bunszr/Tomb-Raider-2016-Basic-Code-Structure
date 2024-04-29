using UnityEngine;

public struct OnWeaponReloadingEnterEvent
{
    public readonly AnimatorStateInfo stateInfo;
    public readonly AnimationStateInfoTypeScriptable animationStateInfoType;

    public OnWeaponReloadingEnterEvent(AnimatorStateInfo stateInfo, AnimationStateInfoTypeScriptable animationStateInfoType)
    {
        this.stateInfo = stateInfo;
        this.animationStateInfoType = animationStateInfoType;
    }
}