using UnityEngine;
using UniRx;

public interface IAnimator
{
    Animator Animator { get; }
    MessageBroker AnimatorMessageBroker { get; } // To listen and publish animator state machine behaviour events in local scope
}