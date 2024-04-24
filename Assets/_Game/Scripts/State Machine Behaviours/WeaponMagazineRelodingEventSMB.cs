using UniRx;
using UnityEngine;

public class WeaponMagazineRelodingEventSMB : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MessageBroker.Default.Publish<OnWeaponReloadingEnterEvent>(new OnWeaponReloadingEnterEvent(stateInfo));
    }
}
