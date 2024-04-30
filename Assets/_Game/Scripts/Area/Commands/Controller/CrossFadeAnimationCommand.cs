using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class CrossFadeAnimationCommand : IAreaCommad
    {
        TriggeredPlayerReference triggeredPlayerReference;
        string stateName;
        float normalizedTransitionDuration;
        int stateNameHash;

        public CrossFadeAnimationCommand(TriggeredPlayerReference triggeredPlayerReference, string stateName, float normalizedTransitionDuration = .15f)
        {
            this.stateName = stateName;
            this.normalizedTransitionDuration = normalizedTransitionDuration;
            this.triggeredPlayerReference = triggeredPlayerReference;
            stateNameHash = Animator.StringToHash(stateName);
        }

        public CrossFadeAnimationCommand(TriggeredPlayerReference triggeredPlayerReference, int stateNameHash, float normalizedTransitionDuration = .15f)
        {
            this.stateNameHash = stateNameHash;
            this.normalizedTransitionDuration = normalizedTransitionDuration;
            this.triggeredPlayerReference = triggeredPlayerReference;
        }

        public void Enter() => triggeredPlayerReference.Player.Animator.CrossFade(stateNameHash, normalizedTransitionDuration);

        public void Exit() { }

        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}