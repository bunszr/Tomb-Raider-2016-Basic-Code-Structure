namespace TriggerableAreaNamespace
{
    public class PressKeyCommand : IAreaCommad
    {
        IAreaInput _areaInput;
        public PressKeyCommand(IAreaInput areaInput) => _areaInput = areaInput;
        public void Enter() { }
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => _areaInput.HasPressedCollectItemKey ? TaskStatusEnum.Success : TaskStatusEnum.Running;
    }
}