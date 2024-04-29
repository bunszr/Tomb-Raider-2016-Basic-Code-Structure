using UnityEngine;

namespace TriggerableAreaNamespace
{
    public interface INotAllowedTriggerable
    {
        GameObject NotAllowedGo { get; }
        bool NotAllowedCondition { get; }
    }
}