using UnityEngine;

public class BulletBase : MonoBehaviour, IBullet
{
    [SerializeField] Rigidbody rb;

    public Transform Transform => transform;
    public Rigidbody Rb => rb;
}