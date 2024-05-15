using UnityEngine;

public interface ICollisionEnterExit
{
    void Activate();
    void Deactivate();
    void OnCustomCollisionEnter(Collision other);
    void OnCustomCollisionExit(Collision other);
}