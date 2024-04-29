using UniRx;
using UnityEngine;

public class WeaponMagazineRelodingEventSMB : StateMachineBehaviour
{
    public AnimationStateInfoTypeScriptable animationStateInfoType;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MessageBroker.Default.Publish<OnWeaponReloadingEnterEvent>(new OnWeaponReloadingEnterEvent(stateInfo, animationStateInfoType));
    }
}