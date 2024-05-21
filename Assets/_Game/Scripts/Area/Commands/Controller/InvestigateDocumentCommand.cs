using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class InvestigateDocumentCommand : IAreaCommad
    {
        IDisposable _disposable;
        float nextTime;

        TriggeredPlayerReference triggeredPlayerReference;

        public InvestigateDocumentCommand(TriggeredPlayerReference triggeredPlayerReference)
        {
            this.triggeredPlayerReference = triggeredPlayerReference;
        }

        public void Enter()
        {
            _disposable = triggeredPlayerReference.Player.AnimatorMessageBroker.Receive<OnAnimationStateEnterEvent>()
                          .Where(x => x.stateInfoEnum == StateInfoEnum.InvestigateDocument).Subscribe(OnAnimEnter);

            nextTime = 0f;
            triggeredPlayerReference.Player.Animator.SetTrigger(APs.InvestigateDocumentTrigger);
        }

        public void Exit() => _disposable.Dispose();

        public TaskStatusEnum OnUpdate()
        {
            return nextTime != 0f && Time.time > nextTime ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }

        void OnAnimEnter(OnAnimationStateEnterEvent onReloadingEnterEvent) => nextTime = Time.time + onReloadingEnterEvent.stateInfo.length;
    }
}