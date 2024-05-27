using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaCampsiteController : AreaBaseController
    {
        protected override void Start()
        {
            base.Start();

            AreaCampsite areaCampsite = areaBase as AreaCampsite;

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] {
                    new PressKeyCommand(() => IM.Ins.Input.AreaInput.HasPressedSitCampsiteKey),
                    new AreaHasTriggeredCommand(triggerCustom),
                    new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new ToggleActivationGameObjectCommand(areaCampsite.PopUpGo, false),
                new ChangePlayerInputCommand(PlayerInputType.None),
                new ActivateCampsiteFirstPanelCommand(areaCampsite.campsiteFirstPanelToOpenGo),
                new WaitForOnCampsiteExitCommand(),
                new ChangePlayerInputCommand(PlayerInputType.Normal),
                new ToggleActivationGameObjectCommand(areaCampsite.PopUpGo, true),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        protected override void OnFinishedExecutionOfCommands()
        {
            base.OnFinishedExecutionOfCommands();
            commandExecuter.Deactivate();
            commandExecuter.Activate();
        }
    }
}