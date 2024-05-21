using UniRx;
using UnityEngine;

public class OnAnimationStateEnterSMB : StateMachineBehaviour
{
    MessageBroker messageBroker;
    public StateInfoEnum stateInfoEnum;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messageBroker.Publish<OnAnimationStateEnterEvent>(new OnAnimationStateEnterEvent(animator, stateInfo, stateInfoEnum, layerIndex));
    }

    public void SetMessageBroker(MessageBroker messageBroker) => this.messageBroker = messageBroker;
}