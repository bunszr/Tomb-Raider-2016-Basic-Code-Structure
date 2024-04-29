namespace TriggerableAreaNamespace
{
    public interface IAreaCommad
    {
        void Enter();
        void Exit();
        TaskStatusEnum OnUpdate();
    }
}