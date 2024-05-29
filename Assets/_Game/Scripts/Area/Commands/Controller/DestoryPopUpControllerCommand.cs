using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class DestoryPopUpControllerCommand : IAreaCommad
    {
        AreaBase areaBase;
        public DestoryPopUpControllerCommand(AreaBase areaBase) => this.areaBase = areaBase;
        public void Enter() => GameObject.Destroy(areaBase.controller.GetComponent<AreaBasePopUpController>());
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}