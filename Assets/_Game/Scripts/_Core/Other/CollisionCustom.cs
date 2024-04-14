using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionCustom : MonoBehaviour
{
    public event System.Action<Collision> onCollisionEnterEvent;
    public event System.Action<Collision> onCollisionExitEvent;

    private void OnCollisionEnter(Collision other)
    {
        onCollisionEnterEvent?.Invoke(other);
    }

    private void OnCollisionExit(Collision other)
    {
        onCollisionExitEvent?.Invoke(other);
    }
}