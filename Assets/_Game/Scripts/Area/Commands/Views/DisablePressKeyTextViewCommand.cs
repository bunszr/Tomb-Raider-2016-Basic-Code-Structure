namespace TriggerableAreaNamespace
{
    public class DisablePressKeyPopUpViewCommand : IAreaCommad
    {
        AreaInventoryItem areaInventoryItem;
        public DisablePressKeyPopUpViewCommand(AreaInventoryItem areaInventoryItem) => this.areaInventoryItem = areaInventoryItem;
        public void Enter() => areaInventoryItem.PopUpGo.SetActive(false);
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}