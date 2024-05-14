using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    [System.Serializable]
    public class DisableCharacterMovementCommand : IAreaCommad
    {
        TriggeredPlayerReference triggeredPlayerReference;

        public DisableCharacterMovementCommand(TriggeredPlayerReference triggeredPlayerReference)
        {
            this.triggeredPlayerReference = triggeredPlayerReference;
        }
        public void Enter()
        {
            triggeredPlayerReference.Player.ThirdPersonInputMonobehaviour.enabled = false; // TODO
            triggeredPlayerReference.Player.Input = Vector3.zero;
            triggeredPlayerReference.Player.Rb.velocity = Vector3.zero;
            triggeredPlayerReference.Player.Rb.angularVelocity = Vector3.zero;
        }

        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}