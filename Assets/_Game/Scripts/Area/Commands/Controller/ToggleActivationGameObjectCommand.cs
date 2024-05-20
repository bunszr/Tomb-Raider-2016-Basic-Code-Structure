using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class ToggleActivationGameObjectCommand : IAreaCommad
    {
        GameObject gameObject;
        bool isActive;

        public ToggleActivationGameObjectCommand(GameObject gameObject, bool isActive)
        {
            this.gameObject = gameObject;
            this.isActive = isActive;
        }

        public void Enter() => gameObject.SetActive(isActive);
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}