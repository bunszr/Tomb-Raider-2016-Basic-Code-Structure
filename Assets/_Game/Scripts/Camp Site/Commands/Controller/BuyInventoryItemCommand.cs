namespace CampSite
{
    public class BuyInventoryItemCommand : ICSBExecute
    {
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;
        public BuyInventoryItemCommand(WeaponFeatureTypeScriptable weaponFeatureTypeScriptable) => this.weaponFeatureTypeScriptable = weaponFeatureTypeScriptable;
        public void Execute() => weaponFeatureTypeScriptable.costDatas.Foreach(x => x.inventoryItem.QuantityRP.Value -= x.costQuantity);
    }
}