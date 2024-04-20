using UnityEngine;

namespace CampSite
{
    public class BuyInventoryItemState : CSBStateBase
    {
        WeaponDataScriptable weaponDataScriptable;

        public BuyInventoryItemState(MonoBehaviour mono, WeaponDataScriptable weaponDataScriptable, bool needsExitTime = false, bool isGhostState = true) : base(mono, needsExitTime, isGhostState)
        {
            this.weaponDataScriptable = weaponDataScriptable;
        }

        public override void OnEnter()
        {
            WeaponFeatureTypeScriptable weaponFeatureTypeScriptable = csbBase.FeatureTypeScriptable as WeaponFeatureTypeScriptable;
            weaponFeatureTypeScriptable.costDatas.Foreach(x => x.inventoryItem.QuantityRP.Value -= x.costQuantity);
        }
    }
}