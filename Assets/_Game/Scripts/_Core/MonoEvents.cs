using UnityEngine;

public class MonoEvents : MonoBehaviour
{
    public event System.Action onUpdate;
    public event System.Action onFixedUpdate;

    private void Update() => onUpdate?.Invoke();
    private void FixedUpdate() => onFixedUpdate?.Invoke();
}