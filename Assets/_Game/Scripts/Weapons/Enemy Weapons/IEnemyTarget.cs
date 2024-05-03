using UnityEngine;

namespace WeaponNamescape.Enemy
{
    public interface IEnemyTarget
    {
        Transform EnemyTargetTransform { get; }
        Vector3 BulletTargetLocation { get; }
    }
}