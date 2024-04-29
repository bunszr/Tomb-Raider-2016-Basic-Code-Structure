using UnityEngine;

namespace TriggerableAreaNamespace
{
    public interface ITriggerEnterExit
    {
        void Activate();
        void Deactivate();
        void OnCustomTriggerEnter(Collider other);
        void OnCustomTriggerExit(Collider other);
    }
}