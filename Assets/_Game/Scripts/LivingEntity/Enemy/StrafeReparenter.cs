using UnityEngine;

public class StrafeReparenter : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = transform.parent.parent;
    }
}