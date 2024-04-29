using UnityEngine;

namespace TriggerableAreaNamespace
{
    public interface ITriggerablePopUp
    {
        GameObject PopUpGo { get; }
        bool HasPopUp { get; }
    }
}