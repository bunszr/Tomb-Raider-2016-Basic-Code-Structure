using UnityEngine;

public class WeponHolderChanger : MonoBehaviour
{
    [SerializeField] Transform weaponHolderUnderHand;

    void Awake()
    {
        transform.parent = weaponHolderUnderHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
