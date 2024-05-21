using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Camera cam;
    private void Awake() => cam = Camera.main;
    private void OnEnable() => UpdateManager.Ins.RegisterAsUpdate(this, OnUpdate);
    private void OnDisable()
    {
        // If we don't check "IsNotNull" instead of UpdateManager.Ins != null, then throw error in console like that "Some objects were not cleaned up when closing the scene.". UpdateManager.Ins never be null. There will be create new gameobject as UpdateManager in this method 
        if (UpdateManager.IsNotNull) UpdateManager.Ins.UnregisterAsUpdate(this, OnUpdate);
    }
    void OnUpdate() => transform.rotation = Quaternion.LookRotation(cam.transform.forward);
}
