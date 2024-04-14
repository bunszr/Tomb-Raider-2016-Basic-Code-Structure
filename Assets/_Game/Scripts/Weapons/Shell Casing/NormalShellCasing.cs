using UnityEngine;

public class NormalShellCasing : MonoBehaviour, IShellCasing
{
    [SerializeField] Rigidbody rb;
    public Transform Transform => transform;
    public Rigidbody Rb => rb;
}
