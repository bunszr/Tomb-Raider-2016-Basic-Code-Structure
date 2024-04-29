using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class IncereaseInventoryItemCommand : IAreaCommad
    {
        AreaInventoryItem areaInventoryItem;

        public IncereaseInventoryItemCommand(AreaInventoryItem areaInventoryItem) => this.areaInventoryItem = areaInventoryItem;
        public void Enter()
        {
            areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value = Mathf.Min(areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value + areaInventoryItem.ItemCountToTake, areaInventoryItem.inventoryItemScriptableBase.MaxQuantity);
        }
        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}