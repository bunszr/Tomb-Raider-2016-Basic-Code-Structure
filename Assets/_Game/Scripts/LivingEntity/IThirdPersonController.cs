using UnityEngine;

public interface IThirdPersonController
{
    Transform Transform { get; }
    float MoveSpeed { get; }
    bool IsStrafe { get; set; }
    Vector3 Input { get; set; }
    Animator Animator { get; }
    Transform StrafeDirectionTransform { get; }
}