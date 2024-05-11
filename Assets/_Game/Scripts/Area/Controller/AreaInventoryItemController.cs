using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItemController : MonoBehaviour
    {
        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaInventoryItem areaInventoryItem;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();

            Func<bool> areaConditionCheck = new Func<bool>(() => areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value < areaInventoryItem.inventoryItemScriptableBase.MaxQuantity);

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] { new PressKeyCommand(IM.Ins.Input.AreaInput), new AreaHasTriggeredCommand(triggerCustom, areaConditionCheck), new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new DestoryAreaCommonViewerCommand(areaInventoryItem),
                new DisableCharacterMovementCommand(TriggeredPlayerReference),
                new CollectAnimationCommand(TriggeredPlayerReference, 0),
                new TakenInventoryItemViewCommand(areaInventoryItem),
                new IncereaseInventoryItemCommand(areaInventoryItem),
                new EnableCharacterMovementCommand(TriggeredPlayerReference),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        void OnFinishedExecutionOfCommands()
        {
            commandExecuter.Deactivate();
            Destroy(areaInventoryItem.transform.parent.gameObject, 1);
        }
    }
}