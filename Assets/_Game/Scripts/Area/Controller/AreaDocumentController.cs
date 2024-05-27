using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDocumentController : AreaBaseController
    {
        protected override void Start()
        {
            base.Start();

            AreaDocument areaDocument = areaBase as AreaDocument;

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

        protected override void OnFinishedExecutionOfCommands()
        {
            base.OnFinishedExecutionOfCommands();
            commandExecuter.Deactivate();
            Destroy(areaBase.transform.parent.gameObject, 1);
        }
    }
}