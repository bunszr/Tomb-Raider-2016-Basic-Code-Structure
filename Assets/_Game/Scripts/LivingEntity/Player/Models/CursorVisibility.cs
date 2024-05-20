using UnityEngine;

public class CursorVisibility : MonoBehaviour
{
    [SerializeField] bool isVisible;

    private void Start()
    {
        if (isVisible)
        {
            Cursor.visible = isVisible;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = isVisible;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}