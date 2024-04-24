using UnityEngine;

public struct OnWeaponReloadingEnterEvent
{
    public readonly AnimatorStateInfo stateInfo;
    public OnWeaponReloadingEnterEvent(AnimatorStateInfo stateInfo) => this.stateInfo = stateInfo;
}