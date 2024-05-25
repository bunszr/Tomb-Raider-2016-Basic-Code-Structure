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
                new ChangePlayerInputCommand(PlayerInputType.None),
                new ToggleCameraCommand(areaDocument, TriggeredPlayerReference, true),
                new ParalelCommand(new IAreaCommad[] {
                    new CrossFadeAnimAndWaitUntilFinishCommand(TriggeredPlayerReference, areaDocument.investigateDocumentCommandData),
                    new CameraFieldOfViewCommand(areaDocument, areaDocument.cameraFieldOfViewCommandData) }),
                new ToggleCameraCommand(areaDocument, TriggeredPlayerReference, false),
                new ChangePlayerInputCommand(PlayerInputType.Normal),
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