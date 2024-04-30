using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class CollectAnimationCommand : IAreaCommad
    {
        IDisposable _disposable;
        float nextTime;

        TriggeredPlayerReference triggeredPlayerReference;
        int collectInventoryItemInt;

        public CollectAnimationCommand(TriggeredPlayerReference triggeredPlayerReference, int collectInventoryItemInt)
        {
            this.triggeredPlayerReference = triggeredPlayerReference;
            this.collectInventoryItemInt = collectInventoryItemInt;
        }

        public void Enter()
        {
            _disposable = MessageBroker.Default.Receive<OnAnimationStateEnterEvent>()
                          .Where(x => x.stateInfoEnum == StateInfoEnum.CollectInventoryItem).Subscribe(OnAnimEnter);

            nextTime = 0f;
            triggeredPlayerReference.Player.Animator.SetInteger(APs.CollectInventoryItemInt, collectInventoryItemInt);
            triggeredPlayerReference.Player.Animator.SetTrigger(APs.CollectInventoryItemTrigger);
        }

        public void Exit() => _disposable.Dispose();

        public TaskStatusEnum OnUpdate()
        {
            return nextTime != 0f && Time.time > nextTime ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }

        void OnAnimEnter(OnAnimationStateEnterEvent onReloadingEnterEvent) => nextTime = Time.time + onReloadingEnterEvent.stateInfo.length;
    }
}