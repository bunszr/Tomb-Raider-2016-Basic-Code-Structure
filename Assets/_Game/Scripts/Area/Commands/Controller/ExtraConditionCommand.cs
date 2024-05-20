using System;

namespace TriggerableAreaNamespace
{
    public class ExtraConditionCommand : IAreaCommad
    {
        Func<bool> extraCondition;
        public ExtraConditionCommand(Func<bool> extraCondition) => this.extraCondition = extraCondition;
        public void Enter() { }
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => extraCondition() ? TaskStatusEnum.Success : TaskStatusEnum.Running;
    }
}