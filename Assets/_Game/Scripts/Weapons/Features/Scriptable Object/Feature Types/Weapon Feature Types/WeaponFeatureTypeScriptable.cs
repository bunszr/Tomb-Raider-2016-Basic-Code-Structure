using Inventory;

public class WeaponFeatureTypeScriptable : FeatureTypeScriptable
{
    public CostData[] costDatas;

    [System.Serializable]
    public class CostData
    {
        public InventoryItemScriptableBase inventoryItem;
        public int costQuantity = 1;
    }
}
