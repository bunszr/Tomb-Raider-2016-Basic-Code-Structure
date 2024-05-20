using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDestructibleController : MonoBehaviour
    {
        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaDestructible areaDestructible;

        Rigidbody[] fragmentsRb;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();

            Func<bool> pressPunchKeyConditionCheck = new Func<bool>(() => IM.Ins.Input.AreaInput.HasPressedHitKey);

            fragmentsRb = areaDestructible.fragmentsHolder.GetComponentsInChildren<Rigidbody>();

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] {
                    new PressKeyCommand(() => IM.Ins.Input.AreaInput.HasPressedCollectItemKey),
                    new AreaHasTriggeredCommand(triggerCustom),
                    new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new DestoryAreaCommonViewerCommand(areaDestructible),
                new CrossFadeAnimationCommand(TriggeredPlayerReference, areaDestructible.punchWallIdleAnim),
                new ChangePlayerInputCommand(PlayerInputType.None),
                new ToggleCameraCommand(areaDestructible, TriggeredPlayerReference, true),
                new MovePlayerToLocationCommand(areaDestructible, TriggeredPlayerReference),
                new ParalelCommand(new IAreaCommad[] {
                    new BreakWallCommand(TriggeredPlayerReference, fragmentsRb, IM.Ins.Input.AreaInput, areaDestructible.maxPunchCount),
                    new PressKeyToInteractionWithDelayCommand(areaDestructible.punchPopUpGo, pressPunchKeyConditionCheck, 1, areaDestructible.maxPunchCount) }),
                new CrossFadeAnimationCommand(TriggeredPlayerReference, APs.CrossFadeEmptyState),
                new ToggleCameraCommand(areaDestructible, TriggeredPlayerReference, false),
                new ChangePlayerInputCommand(PlayerInputType.Normal),
                new DestroyFragmentWallCommand(fragmentsRb),
            };

            commandExecuter = new CommandExecuter(this, areaCommads) { commandExecuterDebug = commandExecuterDebug };
            commandExecuter.onFinished += OnFinishedExecutionOfCommands;

            commandExecuter.Activate();
        }

        void OnFinishedExecutionOfCommands()
        {
            commandExecuter.Deactivate();
            Destroy(areaDestructible.transform.parent.gameObject, 1);
        }
    }
}