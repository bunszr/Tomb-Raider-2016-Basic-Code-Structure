using UnityEngine;

public class LookAtToCamera : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void Update()
    {
        Vector3 dir = (transform.position - cam.transform.position)._X0Z();
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}