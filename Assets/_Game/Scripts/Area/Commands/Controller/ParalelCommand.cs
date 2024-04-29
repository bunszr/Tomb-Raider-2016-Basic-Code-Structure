using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class ParalelCommand : IAreaCommad
    {
        IAreaCommad[] areaCommads;

        public ParalelCommand(IAreaCommad[] areaCommads) => this.areaCommads = areaCommads;
        public void Enter() => areaCommads.Foreach(x => x.Enter());
        public void Exit() => areaCommads.Foreach(x => x.Exit());

        public TaskStatusEnum OnUpdate()
        {
            bool isAllSuccess = true;
            for (int i = 0; i < areaCommads.Length; i++)
            {
                TaskStatusEnum taskStatusEnum = areaCommads[i].OnUpdate();
                if (taskStatusEnum != TaskStatusEnum.Success) isAllSuccess = false;
            }
            return isAllSuccess ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }
    }
}