using UnityEngine;
using Dreamteck.Splines;
using UniRx;

public class CoverLocationData : MonoBehaviour
{
    public SplineComputer computer;
    public ReactiveProperty<Enemy> EnemyInCoverRP { get; private set; } = new ReactiveProperty<Enemy>();
}