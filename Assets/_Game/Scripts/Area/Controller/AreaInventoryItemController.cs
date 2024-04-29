using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItemController : MonoBehaviour
    {
        [Inject] IInput _input;

        [SerializeField] AreaInventoryItem areaInventoryItem;
        [SerializeField] TriggerCustom triggerCustom;
        [SerializeField] MonoEvents monoEvents;

        List<ITriggerEnterExit> _triggerEnterExits;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            areaInventoryItem.areaNameText.text = areaInventoryItem.inventoryItemScriptableBase.ItemName;
            areaInventoryItem.itemImages.Foreach(x => x.sprite = areaInventoryItem.inventoryItemScriptableBase.Icon);

            Func<bool> areaConditionCheck = new Func<bool>(() => areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value < areaInventoryItem.inventoryItemScriptableBase.MaxQuantity);

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] { new PressKeyCommand(_input.AreaInput), new AreaHasTriggeredCommand(triggerCustom, areaConditionCheck) }),
                new DisablePressKeyPopUpViewCommand(areaInventoryItem),
                new DisableCharacterMovementCommand(TriggeredPlayerReference),
                new CollectAnimationCommand(TriggeredPlayerReference, 0),
                new TakenInventoryItemViewCommand(areaInventoryItem),
                new IncereaseInventoryItemCommand(areaInventoryItem),
                new EnableCharacterMovementCommand(TriggeredPlayerReference),
            };

            CommandExecuter commandExecuter = new CommandExecuter(monoEvents, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            _triggerEnterExits = new List<ITriggerEnterExit>()
            {
                new AreaNormalTriggerPopUpView(areaInventoryItem),
                new AreaInventoryItemTriggerNotAllowedView(areaInventoryItem),
            };

            _triggerEnterExits.ForEach(x => x.Activate());

            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;

            commandExecuter.Activate();
        }

        void OnFinishedExecutionOfCommands()
        {
            _triggerEnterExits.ForEach(x => x.Deactivate());
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            Destroy(areaInventoryItem.transform.parent.gameObject, 1);
        }

        private void OnCustomTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player)) TriggeredPlayerReference.SetPlayer(player);
        }
    }
}