namespace TriggerableAreaNamespace
{
    public class EnableCharacterMovementCommand : IAreaCommad
    {
        TriggeredPlayerReference triggeredPlayerReference;
        public EnableCharacterMovementCommand(TriggeredPlayerReference triggeredPlayerReference) => this.triggeredPlayerReference = triggeredPlayerReference;
        public void Enter() => triggeredPlayerReference.Player.ThirdPersonInput.enabled = true; // TODO
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}