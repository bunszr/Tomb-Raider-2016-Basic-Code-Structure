namespace TriggerableAreaNamespace
{
    public class ReverseCondition : ICondition
    {
        ICondition _condition;
        public ReverseCondition(ICondition condition) => _condition = condition;
        public bool Check() => !_condition.Check();
    }
}