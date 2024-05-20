using System.Linq;
using Inventory;
using Sirenix.OdinInspector;

public class WeaponFeatureTypeScriptable : FeatureTypeScriptable
{
    public CostData[] costDatas;

    [Button]
    public bool HasEnoughQuantityToBuy()
    {
        if (costDatas.Length == 0) return true;
        return costDatas.All(x => x.costQuantity <= x.inventoryItem.QuantityRP.Value);
    }

    [System.Serializable]
    public class CostData
    {
        public InventoryItemScriptableBase inventoryItem;
        public int costQuantity = 1;
    }
}
