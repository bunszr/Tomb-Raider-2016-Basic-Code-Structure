using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TriggerableAreaNamespace
{
    public class AreaDocumentController : MonoBehaviour
    {
        [Inject] IInput _input;

        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaDocument areaDocument;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();

            Func<bool> areaConditionCheck = new Func<bool>(() => true);

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] { new PressKeyCommand(_input.AreaInput), new AreaHasTriggeredCommand(triggerCustom, areaConditionCheck), new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new DestoryAreaCommonViewerCommand(areaDocument),
                new DisableCharacterMovementCommand(TriggeredPlayerReference),
                new ToggleCameraCommand(areaDocument, TriggeredPlayerReference, true),
                new ParalelCommand(new IAreaCommad[] { new InvestigateDocumentCommand(TriggeredPlayerReference) , new CameraFieldOfViewCommand(areaDocument) }),
                new ToggleCameraCommand(areaDocument, TriggeredPlayerReference, false),
                new EnableCharacterMovementCommand(TriggeredPlayerReference),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        void OnFinishedExecutionOfCommands()
        {
            commandExecuter.Deactivate();
            Destroy(areaDocument.transform.parent.gameObject, 1);
        }
    }
}