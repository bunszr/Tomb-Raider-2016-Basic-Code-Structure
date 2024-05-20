namespace TriggerableAreaNamespace
{
    public class ChangePlayerInputCommand : IAreaCommad
    {
        PlayerInputType playerInputType;
        public ChangePlayerInputCommand(PlayerInputType playerInputType) => this.playerInputType = playerInputType;
        public void Enter() => IM.Ins.Input.ChangePlayerInput(playerInputType);
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}