using UnityEngine;

public class MonoUpdateEvent : MonoBehaviour
{
    public event System.Action onUpdate;

    private void Update() => onUpdate?.Invoke();
}