using UnityEngine;

public class TriggerCustom : MonoBehaviour
{
    public event System.Action<Collider> onTriggerEnterEvent;
    public event System.Action<Collider> onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent?.Invoke(other);
    }
}