using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class DestoryAreaCommonViewerCommand : IAreaCommad
    {
        AreaBase areaBase;
        public DestoryAreaCommonViewerCommand(AreaBase areaBase) => this.areaBase = areaBase;
        public void Enter() => GameObject.Destroy(areaBase.view.GetComponent<AreaCommonViewer>());
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}