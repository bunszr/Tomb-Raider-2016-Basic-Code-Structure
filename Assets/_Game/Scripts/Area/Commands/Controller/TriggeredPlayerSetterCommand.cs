using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class TriggeredPlayerSetterCommand : IAreaCommad
    {
        TriggerCustom triggerCustom;
        TriggeredPlayerReference triggeredPlayerReference;

        public TriggeredPlayerSetterCommand(TriggerCustom triggerCustom, TriggeredPlayerReference triggeredPlayerReference)
        {
            this.triggerCustom = triggerCustom;
            this.triggeredPlayerReference = triggeredPlayerReference;
        }

        public void Enter()
        {
            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent += OnCustomTriggerExit;
        }

        public void Exit()
        {
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent -= OnCustomTriggerExit;
        }

        private void OnCustomTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player)) triggeredPlayerReference.SetPlayer(player);
        }

        private void OnCustomTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player)) triggeredPlayerReference.SetPlayer(null);
        }

        public TaskStatusEnum OnUpdate()
        {
            return triggeredPlayerReference.Player != null ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }
    }
}