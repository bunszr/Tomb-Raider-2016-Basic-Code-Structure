using UnityEngine;
using UniRx;

public interface IGiveDamage
{
    Transform Transform { get; }
    float DamageValue { get; }
    ReactiveProperty<bool> IsHitTo { get; }
}