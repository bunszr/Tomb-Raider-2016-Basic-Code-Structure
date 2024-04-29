using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class ToggleCameraCommand : IAreaCommad
    {
        IAreaCamera _areaCamera;
        AreaBase areaBase;
        TriggeredPlayerReference triggeredPlayerReference;
        bool isActive;

        public ToggleCameraCommand(AreaBase areaBase, TriggeredPlayerReference triggeredPlayerReference, bool isActive)
        {
            this.areaBase = areaBase;
            this.triggeredPlayerReference = triggeredPlayerReference;
            _areaCamera = areaBase as IAreaCamera;
            this.isActive = isActive;
        }

        public void Enter()
        {
            _areaCamera.VirtualCamera.gameObject.SetActive(isActive);
            _areaCamera.VirtualCamera.LookAt = triggeredPlayerReference.Player.transform;
        }

        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}