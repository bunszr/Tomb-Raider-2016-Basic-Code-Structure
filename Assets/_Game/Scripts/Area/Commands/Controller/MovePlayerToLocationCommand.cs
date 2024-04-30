using DG.Tweening;

namespace TriggerableAreaNamespace
{
    public class MovePlayerToLocationCommand : IAreaCommad
    {
        IPlayerLocation _playerLocation;
        AreaBase areaBase;
        TriggeredPlayerReference triggeredPlayerReference;
        bool isActive;

        public MovePlayerToLocationCommand(AreaBase areaBase, TriggeredPlayerReference triggeredPlayerReference)
        {
            this.areaBase = areaBase;
            this.triggeredPlayerReference = triggeredPlayerReference;
            _playerLocation = areaBase as IPlayerLocation;
        }

        public void Enter()
        {
            isActive = false;
            triggeredPlayerReference.Player.Rb.DOMove(_playerLocation.PlayerLocation.position, .3f);
            triggeredPlayerReference.Player.Rb.DORotate(_playerLocation.PlayerLocation.eulerAngles, .3f).onComplete = OnComplete;
        }

        public void Exit() { }
        public TaskStatusEnum OnUpdate() => isActive ? TaskStatusEnum.Success : TaskStatusEnum.Running;

        void OnComplete() => isActive = true;
    }
}