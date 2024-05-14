using UniRx;
using UnityEngine;

public class OnAnimationStateEnterSMB : StateMachineBehaviour
{
    public StateInfoEnum stateInfoEnum;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MessageBroker.Default.Publish<OnAnimationStateEnterEvent>(new OnAnimationStateEnterEvent(animator, stateInfo, stateInfoEnum, layerIndex));
    }
}