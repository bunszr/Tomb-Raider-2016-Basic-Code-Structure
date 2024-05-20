using UnityEngine;

public interface IBullet
{
    Transform Transform { get; }
    Rigidbody Rb { get; }
}