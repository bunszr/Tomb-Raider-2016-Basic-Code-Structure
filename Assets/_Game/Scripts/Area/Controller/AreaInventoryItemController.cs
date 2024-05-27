using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItemController : AreaBaseController
    {
        protected override void Start()
        {
            base.Start();

            AreaInventoryItem areaInventoryItem = areaBase as AreaInventoryItem;

            Func<bool> areaConditionCheck = new Func<bool>(() => areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value < areaInventoryItem.inventoryItemScriptableBase.MaxQuantity);

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] {
                    new PressKeyCommand(() => IM.Ins.Input.AreaInput.HasPressedCollectItemKey),
                    new AreaHasTriggeredCommand(triggerCustom),
                    new ExtraConditionCommand(areaConditionCheck),
                    new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new DestoryAreaCommonViewerCommand(areaInventoryItem),
                new ChangePlayerInputCommand(PlayerInputType.None),
                new CollectAnimationCommand(TriggeredPlayerReference, 0),
                new TakenInventoryItemViewCommand(areaInventoryItem),
                new IncereaseInventoryItemCommand(areaInventoryItem),
                new ChangePlayerInputCommand(PlayerInputType.Normal),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        protected override void OnFinishedExecutionOfCommands()
        {
            base.OnFinishedExecutionOfCommands();
            commandExecuter.Deactivate();
            Destroy(areaBase.transform.parent.gameObject, 1);
        }
    }
}