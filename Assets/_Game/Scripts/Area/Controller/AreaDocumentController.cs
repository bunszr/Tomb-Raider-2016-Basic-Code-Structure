using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDocumentController : MonoBehaviour
    {
        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaDocument areaDocument;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] {
                    new PressKeyCommand(() => IM.Ins.Input.AreaInput.HasPressedCollectItemKey),
                    new AreaHasTriggeredCommand(triggerCustom),
                    new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
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