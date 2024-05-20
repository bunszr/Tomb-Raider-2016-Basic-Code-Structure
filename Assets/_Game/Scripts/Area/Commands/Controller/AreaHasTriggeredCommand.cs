using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaHasTriggeredCommand : IAreaCommad
    {
        TriggerCustom triggerCustom;
        bool isEnterPlayer;

        public AreaHasTriggeredCommand(TriggerCustom triggerCustom) => this.triggerCustom = triggerCustom;

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
            if (other.TryGetComponent(out Player player)) isEnterPlayer = true;
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