using CampSite;
using UniRx;

namespace TriggerableAreaNamespace
{
    [System.Serializable]
    public class WaitForOnCampsiteExitCommand : IAreaCommad
    {
        System.IDisposable disposable;
        bool isDone;

        public void Enter() => disposable = MessageBroker.Default.Receive<OnCampsiteExitEvent>().Subscribe(OnCampsiteExit);
        public void Exit() { disposable.Dispose(); isDone = false; }
        public TaskStatusEnum OnUpdate() => isDone ? TaskStatusEnum.Success : TaskStatusEnum.Running;

        void OnCampsiteExit(OnCampsiteExitEvent onCampsiteExitEvent) { isDone = true; }
    }
}