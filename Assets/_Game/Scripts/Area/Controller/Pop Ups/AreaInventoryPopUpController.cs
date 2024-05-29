namespace TriggerableAreaNamespace
{
    public class AreaInventoryPopUpController : AreaBasePopUpController
    {
        AreaPopUpTrigger normalPopUpTrigger;
        AreaPopUpTrigger notAllowPopUpTrigger;

        protected override void Start()
        {
            base.Start();

            AreaInventoryItem areaInventoryItem = areaBase as AreaInventoryItem;

            areaInventoryItem.areaNameText.text = areaInventoryItem.inventoryItemScriptableBase.ItemName;
            areaInventoryItem.itemImages.Foreach(x => x.sprite = areaInventoryItem.inventoryItemScriptableBase.Icon);

            normalPopUpTrigger = new AreaPopUpTrigger(triggerCustom,
                new ICondition[] {
                    new InventoryItemQuantityIsLessThanMaxCommand(areaInventoryItem.inventoryItemScriptableBase) },
                new ShowNormalPopUpView(areaInventoryItem)
            );

            notAllowPopUpTrigger = new AreaPopUpTrigger(triggerCustom,
                new ICondition[] {
                   new ReverseCondition(new InventoryItemQuantityIsLessThanMaxCommand(areaInventoryItem.inventoryItemScriptableBase)) },
                new ShowNotAllowedPopUpView(areaInventoryItem)
            );

            normalPopUpTrigger.Enter();
            notAllowPopUpTrigger.Enter();
        }

        private void OnDestroy()
        {
            normalPopUpTrigger.Exit();
            notAllowPopUpTrigger.Exit();
        }
    }
}