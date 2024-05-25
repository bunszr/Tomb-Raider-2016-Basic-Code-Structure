using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class CrossFadeAnimAndWaitUntilFinishCommand : IAreaCommad
    {
        [System.Serializable]
        public class CrossFadeAnimAndWaitUntilFinishCommandData
        {
            [SerializeField] string animStateName;

            public string AnimStateName { get => animStateName; }
        }

        CrossFadeAnimAndWaitUntilFinishCommandData data;
        IDisposable _disposable;
        float nextTime;

        TriggeredPlayerReference triggeredPlayerReference;

        public CrossFadeAnimAndWaitUntilFinishCommand(TriggeredPlayerReference triggeredPlayerReference, CrossFadeAnimAndWaitUntilFinishCommandData data)
        {
            this.triggeredPlayerReference = triggeredPlayerReference;
            this.data = data;
        }

        public void Enter()
        {
            _disposable = triggeredPlayerReference.Player.AnimatorMessageBroker.Receive<OnAnimationStateEnterEvent>()
                          .Where(x => x.stateInfo.IsName(data.AnimStateName)).Subscribe(OnAnimEnter);

            nextTime = 0f;
            triggeredPlayerReference.Player.Animator.CrossFade(data.AnimStateName, .1f);
        }

        public void Exit() => _disposable.Dispose();

        public TaskStatusEnum OnUpdate()
        {
            return nextTime != 0f && Time.time > nextTime ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }

        void OnAnimEnter(OnAnimationStateEnterEvent onReloadingEnterEvent) => nextTime = Time.time + onReloadingEnterEvent.stateInfo.length;
    }
}