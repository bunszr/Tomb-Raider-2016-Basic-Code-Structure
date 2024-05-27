using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaDestructibleController : AreaBaseController
    {
        Rigidbody[] fragmentsRb;

        protected override void Start()
        {
            base.Start();

            AreaDestructible areaDestructible = areaBase as AreaDestructible;

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

        protected override void OnFinishedExecutionOfCommands()
        {
            base.OnFinishedExecutionOfCommands();
            commandExecuter.Deactivate();
            Destroy(areaBase.transform.parent.gameObject, 1);
        }
    }
}