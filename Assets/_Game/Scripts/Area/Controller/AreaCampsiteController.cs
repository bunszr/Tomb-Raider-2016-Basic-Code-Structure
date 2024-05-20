using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaCampsiteController : MonoBehaviour
    {
        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaCampsite areaCampsite;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] {
                    new PressKeyCommand(() => IM.Ins.Input.AreaInput.HasPressedSitCampsiteKey),
                    new AreaHasTriggeredCommand(triggerCustom),
                    new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new ToggleActivationGameObjectCommand(areaCampsite.PopUpGo, false),
                new DisableCharacterMovementCommand(TriggeredPlayerReference),
                new ActivateCampsiteFirstPanelCommand(areaCampsite.campsiteFirstPanelToOpenGo),
                new WaitForOnCampsiteExitCommand(),
                new EnableCharacterMovementCommand(TriggeredPlayerReference),
                new ToggleActivationGameObjectCommand(areaCampsite.PopUpGo, true),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        void OnFinishedExecutionOfCommands()
        {
            commandExecuter.Deactivate();
            commandExecuter.Activate();
        }
    }
}