using UniRx;
using UnityEngine;

public class OnAnimationStateExitSMB : StateMachineBehaviour
{
    MessageBroker messageBroker;
    public StateInfoEnum stateInfoEnum;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messageBroker.Publish<OnAnimationStateExitEvent>(new OnAnimationStateExitEvent(animator, stateInfo, stateInfoEnum, layerIndex));
    }

    public void SetMessageBroker(MessageBroker messageBroker) => this.messageBroker = messageBroker;
}