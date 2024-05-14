using UniRx;
using UnityEngine;

public class OnAnimationStateExitSMB : StateMachineBehaviour
{
    public StateInfoEnum stateInfoEnum;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MessageBroker.Default.Publish<OnAnimationStateExitEvent>(new OnAnimationStateExitEvent(animator, stateInfo, stateInfoEnum, layerIndex));
    }
}