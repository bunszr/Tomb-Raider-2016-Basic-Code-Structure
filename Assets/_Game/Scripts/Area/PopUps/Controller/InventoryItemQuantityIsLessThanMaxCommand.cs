using Inventory;

namespace TriggerableAreaNamespace
{
    public class InventoryItemQuantityIsLessThanMaxCommand : ICondition
    {
        InventoryItemScriptableBase inventoryItemScriptableBase;
        public InventoryItemQuantityIsLessThanMaxCommand(InventoryItemScriptableBase inventoryItemScriptableBase) => this.inventoryItemScriptableBase = inventoryItemScriptableBase;
        public bool Check() => inventoryItemScriptableBase.QuantityRP.Value < inventoryItemScriptableBase.MaxQuantity;
    }
}