using System;
using UnityEngine;
using Zenject;

namespace TriggerableAreaNamespace
{
    public class AreaDestructibleController : MonoBehaviour
    {
        [Inject] IInput _input;

        TriggerCustom triggerCustom;
        CommandExecuter commandExecuter;
        [SerializeField] AreaDestructible areaDestructible;

        Rigidbody[] fragmentsRb;

        [SerializeField] CommandExecuter.CommandExecuterDebug commandExecuterDebug;

        public TriggeredPlayerReference TriggeredPlayerReference { get; private set; } = new TriggeredPlayerReference();

        private void Start()
        {
            triggerCustom = gameObject.GetOrAddComponent<TriggerCustom>();


            Func<bool> areaConditionCheck = new Func<bool>(() => true);
            Func<bool> pressPunchKeyConditionCheck = new Func<bool>(() => _input.AreaInput.HasPressedHitKey);

            fragmentsRb = areaDestructible.fragmentsHolder.GetComponentsInChildren<Rigidbody>();

            IAreaCommad[] areaCommads = new IAreaCommad[]
            {
                new ParalelCommand( new IAreaCommad[] { new PressKeyCommand(_input.AreaInput), new AreaHasTriggeredCommand(triggerCustom, areaConditionCheck), new TriggeredPlayerSetterCommand(triggerCustom, TriggeredPlayerReference) }),
                new DestoryAreaCommonViewerCommand(areaDestructible),
                new CrossFadeAnimationCommand(TriggeredPlayerReference, areaDestructible.punchWallIdleAnim),
                new DisableCharacterMovementCommand(TriggeredPlayerReference),
                new ToggleCameraCommand(areaDestructible, TriggeredPlayerReference, true),
                new MovePlayerToLocationCommand(areaDestructible, TriggeredPlayerReference),
                new ParalelCommand(new IAreaCommad[] {
                    new BreakWallCommand(TriggeredPlayerReference, fragmentsRb, _input.AreaInput, areaDestructible.maxPunchCount),
                    new PressKeyToInteractionWithDelayCommand(areaDestructible.punchPopUpGo, pressPunchKeyConditionCheck, 1, areaDestructible.maxPunchCount) }),
                new CrossFadeAnimationCommand(TriggeredPlayerReference, APs.CrossFadeEmptyState),
                new ToggleCameraCommand(areaDestructible, TriggeredPlayerReference, false),
                new EnableCharacterMovementCommand(TriggeredPlayerReference),
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