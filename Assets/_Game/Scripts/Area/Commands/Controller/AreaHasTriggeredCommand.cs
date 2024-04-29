using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaHasTriggeredCommand : IAreaCommad
    {
        TriggerCustom triggerCustom;
        bool isEnterPlayer;
        Func<bool> extraCondition;

        public AreaHasTriggeredCommand(TriggerCustom triggerCustom, Func<bool> extraCondition)
        {
            this.triggerCustom = triggerCustom;
            this.extraCondition = extraCondition;
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
            if (other.TryGetComponent(out Player player) && extraCondition()) isEnterPlayer = true;
        }

        private void OnCustomTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player)) isEnterPlayer = false;
        }

        public TaskStatusEnum OnUpdate()
        {
            return isEnterPlayer ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }
    }
}