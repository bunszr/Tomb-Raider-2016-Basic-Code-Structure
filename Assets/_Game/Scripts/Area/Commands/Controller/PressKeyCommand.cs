using System;

namespace TriggerableAreaNamespace
{
    public class PressKeyCommand : IAreaCommad
    {
        Func<bool> successCondition;
        public PressKeyCommand(Func<bool> successCondition) => this.successCondition = successCondition;
        public void Enter() { }
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => successCondition() ? TaskStatusEnum.Success : TaskStatusEnum.Running;
    }
}