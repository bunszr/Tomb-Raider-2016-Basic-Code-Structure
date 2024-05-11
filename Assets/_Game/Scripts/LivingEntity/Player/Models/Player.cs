using Sirenix.OdinInspector;
using UnityEngine;
using WeaponNamescape.Enemy;
using Zenject;

public class Player : LivingEntity, IEnemyTarget
{
    public Transform EnemyTargetTransform => transform;
    public Vector3 BulletTargetLocation => transform.position + Vector3.up * 1.3f;

    private void Awake()
    {
        StaticColliderManager.PlayerDictionary.Add(transform.GetInstanceID(), this);
        StaticColliderManager.AddIEnemyTarget(transform.GetInstanceID(), this);
    }

    private void OnDestroy()
    {
        StaticColliderManager.PlayerDictionary.Remove(transform.GetInstanceID());
        StaticColliderManager.RemoveIEnemyTarget(transform.GetInstanceID(), this);
    }

    public void ToggleStrafe()
    {

    }
}